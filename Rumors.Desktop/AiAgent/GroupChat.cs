using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.OpenAI;
using Microsoft.SemanticKernel.ChatCompletion;
using System.ClientModel;
using System.Diagnostics;
using System.Text;

namespace Rumors.Desktop.AiAgent
{
#pragma warning disable SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    internal class GroupChat : IAiAssistant
    {
        private OpenAIAssistantAgent _writerAgent = null!;
        private ChatCompletionAgent _reviewerAgent = null!;
        private AgentGroupChat _chat = null!;


        public async Task<string> Chat(string input)
        {
            _chat ??= await CreateChat();

            var userMessage = new ChatMessageContent(AuthorRole.User, input);
            _chat.AddChatMessage(userMessage);

            var sb = new StringBuilder();
            await foreach (ChatMessageContent response in _chat.InvokeAsync())
            {
                sb.AppendLine($"[{response.Role}{response.AuthorName}] - {response.Content}");
                Debug.WriteLine($"[{response.Role}{response.AuthorName}] - {response.Content}");
            }


            return sb.ToString();
        }

        private async Task<AgentGroupChat> CreateChat()
        {
            
            (_writerAgent, _reviewerAgent) = await CreateAgents();

            var chat = new AgentGroupChat(_writerAgent, _reviewerAgent)
            {
                ExecutionSettings = new()
                {
                    TerminationStrategy = new ApprovalTerminationStrategy()
                    {
                        // Only the art-director may approve.
                        Agents = [_reviewerAgent],
                        // Limit total number of turns
                        MaximumIterations = 6,
                    }
                }
            };

            return chat;
        }

        private async Task<(OpenAIAssistantAgent, ChatCompletionAgent)> CreateAgents()
        {
            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;
            string apiKey = configuration["OpenAIKey"]; // Replace with your OpenAI API key
            string modelName = "gpt-3.5-turbo"; // Specify the model you want to use
           // string modelName = "gpt-4"; // Specify the model you want to use
            var clientProvider = OpenAIClientProvider.ForOpenAI(new ApiKeyCredential(apiKey));

            var writerAgent = await OpenAIAssistantAgent.CreateAsync(
                  clientProvider,
                  new OpenAIAssistantDefinition(modelName)
                  {
                      Name = "EmailAssistantAgent",
                      Instructions =
                      """
                        As an email assistant, which process email chains. Your job - find emails, retrive, arrange, cleanup and save their chains. using the available functions. 
                        if user didn't specify where to search, search in subject and body as well. After retrieving the chain, review each email and clean up any unnecessary and redundant content like repeated greetings, signatures, or redundant trailing email threads. 
                        Make sure to maintain the main body of each email with all the important information intact. Present the email chain in chronological order, starting from the earliest to the latest email. 
                        Provide details such as the sender, receiver, date, and time of each email. Also, if the chain later gets forwarded as a whole to another recipient, include this information at the end. 
                        The eventual goal is to present a clear and concise view of the whole conversation for easy understanding and reference.
                        If user asks to save chain, save it from results you got. 
                        """
                  }, new Kernel()
              );
            writerAgent.Kernel.Plugins.AddFromType<EmailTool>("Emails");

            IKernelBuilder builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(modelName, apiKey);
            var kernel = builder.Build();

            var reviewerAgent =
                  new ChatCompletionAgent()
                    {
                        Name = "ReviewerAgent",
                        Instructions = """
                        You are QA agent, you review result of EmailAssistant. 
                        If Email assistant performs find email, ask him to find email chain from this email too. Let him search in chain and in the emails body as well.
                        It should be well formed list with the sender, receiver, date, time and the body of each email.
                        There shoud'n be redundant information, threads, copies, inline appended emails in the body.
                        if you have some objections and remarks tell them EmailAssistant agent. Response Approve if you approve email chain.
                        if Agent says there's no chain ask him once again to parse emails body ant extract a chain from it if possible
                        """,
                        Kernel = kernel
                    };
            

            return (writerAgent, reviewerAgent);
        }

        public async Task DestroyAgent()
        {

            if (_writerAgent != null)
            {
                await _writerAgent.DeleteAsync();
         
            }

     
        }

    }
#pragma warning restore SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning restore SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
