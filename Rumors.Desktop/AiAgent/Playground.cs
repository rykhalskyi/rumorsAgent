using Microsoft.SemanticKernel;
using System.Text;
using Microsoft.SemanticKernel.Agents.OpenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ClientModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rumors.Desktop.AiAgent
{
    public class Playground : IAiAssistant
    {
#pragma warning disable SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

        private OpenAIAssistantAgent? _agent = null!;
        private string _threadId = string.Empty;
        private readonly OpenAIClientProvider _clientProvider;
        private string _agentName;

        private const string Model = "gpt-4o-mini";//"gpt-4"; //"gpt-3.5-turbo"


        public Playground()
        {
            _clientProvider = InitializeProvider();
        }

        private OpenAIClientProvider InitializeProvider()
        {
            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;
            string apiKey = configuration["OpenAIKey"]; 
            _agentName = configuration["OpenAiAgentName"];

            return OpenAIClientProvider.ForOpenAI(new ApiKeyCredential(apiKey));
        }

        private async Task CreateAgent()
        {
            _agent = await OpenAIAssistantAgent.CreateAsync(
                    _clientProvider,
                    new OpenAIAssistantDefinition(Model)
                    {
                        Name = "EmailAssistantAgent",
                        Instructions =
                        """
                        As an email assistant, when processing email chains or conversations, you should first retrieve the emails in the chain using the available functions. 
                        if user didn't specify where to search, search in subject and body as well. If there's no chain, try to parse emails body and present it like a chain if possible. 
                        After retrieving the chain, review each email and clean up any unnecessary and redundant content like repeated greetings, signatures, or redundant trailing email threads. 
                        Make sure to maintain the main body of each email with all the important information intact. Present the email chain in chronological order, starting from the earliest to the latest email. 
                        Provide details such as the sender, receiver, date, and time of each email. Also, if the chain later gets forwarded as a whole to another recipient, include this information at the end. 
                        The eventual goal is to present a clear and concise view of the whole conversation for easy understanding and reference.
                        If user asks to save chain, save it from results you got.
                        """
                    }, new Kernel()
                );

            _agent.Kernel.Plugins.AddFromType<EmailTool>("Emails");
            _threadId = await _agent.CreateThreadAsync();

            _agentName = _agent.Name ?? "";
        }

        private async Task<bool> LoadAgent(string agentName)
        {
            IKernelBuilder builder = Kernel.CreateBuilder();
            var kernel = builder.Build();

            try
            {
                _agent = await OpenAIAssistantAgent.RetrieveAsync(_clientProvider, agentName, kernel);
            }
            catch (Exception)
            {
                return false;
            }

            _agent.Kernel.Plugins.AddFromType<EmailTool>("Emails");
            _threadId = await _agent.CreateThreadAsync();

            return true;
        }

        public async Task<string> Chat(string input)
        {
            if (_agent == null && !await LoadAgent(_agentName)) await CreateAgent();


            if (_agent == null) 
                throw new InvalidOperationException("Agent has not been created. Call CreateAgent");

            await _agent.AddChatMessageAsync(_threadId, new ChatMessageContent(AuthorRole.User, input));

            List<StreamingAnnotationContent> footnotes = [];
            var sb = new StringBuilder();
            await foreach (StreamingChatMessageContent chunk in _agent.InvokeStreamingAsync(_threadId))
            {
                // Capture annotations for footnotes
                footnotes.AddRange(chunk.Items.OfType<StreamingAnnotationContent>());

                // Render chunk with replacements for unicode brackets.
                sb.Append(chunk.Content);
            }

            return sb.ToString();
        }

        public async Task DestroyAgent()
        {
            if (_agent == null) return;

            await Task.WhenAll([
                _agent.DeleteThreadAsync(_threadId),
                _agent.DeleteAsync()
                ]);
        }

#pragma warning restore SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }
}
