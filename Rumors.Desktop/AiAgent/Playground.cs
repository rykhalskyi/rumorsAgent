using Microsoft.SemanticKernel;
using System.Text;
using Microsoft.SemanticKernel.Agents.OpenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ClientModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rumors.Desktop.AiAgent
{
    public class Playground
    {
#pragma warning disable SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

        private OpenAIAssistantAgent? _agent = null!;
        private string _threadId = string.Empty;

        public Playground()
        {
            CreateAgent();
        }

        private async void CreateAgent()
        {
            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;
            string apiKey = configuration["OpenAIKey"]; // Replace with your OpenAI API key
            string modelName = "gpt-4"; // Specify the model you want to use


            var clientProvider = OpenAIClientProvider.ForOpenAI(new ApiKeyCredential(apiKey));

            _agent = await OpenAIAssistantAgent.CreateAsync(
                    clientProvider,
                    new OpenAIAssistantDefinition(modelName)
                    {
                        Name = "AssistantAgent",
                        Instructions =
                        """
                        Analyze the available data to provide an answer to the user's question.
                        If user ask to get emails on some topic, make a search string and try tu use Email plugin
                        if user din't specify where to search, search in subject and body as well.
                        display emails chain as a list and a short story too.
                        """
                    }, new Kernel()
                );

            _agent.Kernel.Plugins.AddFromType<EmailTool>("Emails");
            _threadId = await _agent.CreateThreadAsync();


        }
        public async Task<string> Chat(string input)
        {
            if (_agent == null) throw new InvalidOperationException("Agent has not been created. Call CreateAgent");
              
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
