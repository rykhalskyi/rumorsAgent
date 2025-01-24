using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Rumors.Desktop.Logging;
using System.Diagnostics;
using System.Text;

namespace Rumors.Desktop.AiAgent
{
#pragma warning disable SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning disable SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    internal class GroupChat : IAiAssistant
    {
        private ChatCompletionAgent _emailAssistant = null!;
        private ChatCompletionAgent _reviewer = null!;

        private const string Model = "gpt-3.5-turbo";
        private readonly IChatNotifier _chatNotifier;
        private List<ChatMessageContent> _history = new List<ChatMessageContent>();

        public GroupChat(IChatNotifier chatNotifier)
        {
            _chatNotifier = chatNotifier;
        }

        public async Task<string> Chat(string input)
        {
            var chat = await CreateChat();

            var userMessage = new ChatMessageContent(AuthorRole.User, input);
            
            chat.AddChatMessages(_history);
            chat.AddChatMessage(userMessage);

            var sb = new StringBuilder();
            await foreach (ChatMessageContent response in chat.InvokeAsync())
            {
                sb.AppendLine($"[{response.Role}{response.AuthorName}] - {response.Content}");
            }

            var history =  await chat.GetChatMessagesAsync().ToListAsync();
            history.Reverse();
            _history.AddRange(history);

            //Add some logic to trim a history. pay attension on tool messages after trimming
            
            return sb.ToString();
        }

        private async Task<AgentGroupChat> CreateChat()
        {
            
            (_emailAssistant, _reviewer) = await CreateAgents();

            var chat = new AgentGroupChat(_emailAssistant, _reviewer)
            {
                ExecutionSettings = new()
                {
                    TerminationStrategy = new ApprovalTerminationStrategy()
                    {
                        // Only the art-director may approve.
                        Agents = [_reviewer],
                        // Limit total number of turns
                        MaximumIterations = 6,
                    }
                }
            };

            return chat;
        }

        private async Task<(ChatCompletionAgent, ChatCompletionAgent)> CreateAgents()
        {
            ChatCompletionAgent writerAgent = new() {
                Name = "EmailAssistant",
                Instructions = """
                        You have tools to search through users email, retrieve email chains and save them. Thats your job. You work pn user demand.
                        if user didn't specify where to search, search in subject and body as well. If there's no explicit chain, try to parse emails body and present it like a chain if it's possible. 
                        To find email use "search_for_emails", to get its chain "get_email_chain" mongo db for save only
                        
                        The email chain MUST meet conditions:
                         - Each email in the list MUST contain with the sender, receiver, date, time and the body of each email.
                         - Chain is well formed numered list and contain NO redundant information such as: threads, copies, inline appended, forwarded emails in the emails body.
                         - Inportantinformation MUST NOT be lost

                         if you preperead a chain ask Reviewer to approve it. Only User can ask explicitly to save email chain.
                        """,
                Kernel = CreateKernel(),
                Arguments = new KernelArguments(new OpenAIPromptExecutionSettings() {FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()})
            };
              
            writerAgent.Kernel.Plugins.AddFromType<EmailTool>("Emails");

            ChatCompletionAgent reviewerAgent = new(){
                        Name = "Reviewer",
                        Instructions = """
                        If Email Assistant asks you to review his result, review it.
                        
                        Response 'Approve' ONLY if Email agent responds woth chain AND contidions are met:
                         - Each email in the list MUST contain with the sender, receiver, date, time and the body of each email.
                         - Chain is well formed numered list and contain NO redundant information such as: threads, copies, inline appended, forwarded emails in the emails body.
                         - Inportantinformation MUST NOT be lost

                        If these conditionds are not met, respomse with these conditionsand ask to fixthe chain. 
                        if EmailAssistant says there's no chain or there are forwarded messages in emails body, ask him once again to parse emails body ant extract a chain list from that messages
                        """,
                        Kernel = CreateKernel()
                    };
            
            return (writerAgent, reviewerAgent);
        }

        public async Task DestroyAgent()
        {
           //Not applicible to chatComplition
        }

        private Kernel CreateKernel()
        {
            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;
            string apiKey = configuration["OpenAIKey"]; // Replace with your OpenAI API key

            var builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(
                Model,
                apiKey
                );

            return builder.Build();
        }

    }
#pragma warning restore SKEXP0110 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
#pragma warning restore SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
