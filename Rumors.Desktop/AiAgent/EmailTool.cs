using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Pipes;
using System.ComponentModel;
using System.Text.Json;

namespace Rumors.Desktop.AiAgent
{
    internal class EmailTool
    {
        [KernelFunction("search_for_emails")]
        [Description("Searches for emails in the email client. input argument is search object in JSON of the format" +
            "{ \"Subject\": \"string tosearch in email subject\"," +
            "  \"Body\": \"string tosearch in email body\"," +
            "  \"Sender\": \"string tosearch in email adress of sender\"," +
            "  \"RecievedAfter\": \"Date in format yyyy-mm-dd to serch all email recieved after this date\"," +
            "  \"RrecievedBefore\": \"Date in format yyyy-mm-dd to serch all email recieved before this date\"," +
            "  \"ReadStatus\": \"boolean, true if email has been read\"," +
            "}")]
        [return: Description("string to show to user")]
        public string SearchEmails(string searchQuery)
        {
            var pipeClient = ApplicationEntryPoint.ServiceProvider.GetService<PipeClient>()!;
            var searchObj = JsonSerializer.Deserialize<SearchDto>(searchQuery);

            var response = pipeClient.Send(new SearchMessage { Search = searchObj });
            if (response is SimpleResponseMessage message)
            {
                return message.Message;
            }

            return "Error occured. Wrong response message type";
        }
    }
}
