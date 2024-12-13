using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Pipes;
using System.ComponentModel;
using System.Diagnostics;

namespace Rumors.Desktop.AiAgent
{
    internal class EmailTool
    {
        [KernelFunction("search_for_emails")]
        [Description("Searches emails in email client using string request"+
            "request contains expressions with keywords and conditions"+
            "expressions can be:"+
            "[subject] LIKE '%string_to_search_in_subject%'"+
            "[body] LIKE '%string to search_in_body%'"+
            "[sender] LIKE '%string_to_search_in_sender_email%'"+
            "[received] >,<,=,>=,<= date to search. supports comparision operators" +
            "[status] = value (true/false)." +
            "[subject], [body] and [sender] are string type, [received] is date in format yyyy-mm-dd. [status] is boolean+" +
            "this conditions can be combined with add/or in one expression")]
        [return: Description("string to show to user")]
        public string AdvancedSearchEmails(string searchQuery)
        {
            var pipeClient = ApplicationEntryPoint.ServiceProvider.GetService<PipeClient>()!;

            Debug.WriteLine($"LLM query: {searchQuery}");

            var response = pipeClient.Send(new SearchMessage { Query = searchQuery });
            if (response is SimpleResponseMessage message)
            {
                Debug.WriteLine($"Response: {message.Message}");
                return message.Message;
            }

            return "Error occured. Wrong response message type";
        }
    }
}

