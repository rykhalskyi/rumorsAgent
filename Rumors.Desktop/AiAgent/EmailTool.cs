using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Pipes;
using System.ComponentModel;

namespace Rumors.Desktop.AiAgent
{
    internal class EmailTool
    {
        [KernelFunction("serach_for_emails")]
        [Description("Searcehs for emails in the email client. input argument is search string")]
        [return: Description("string to show to user")]
        public string SearchEmails(string searchString)
        {
            var pipeClient = ApplicationEntryPoint.ServiceProvider.GetService<PipeClient>()!; 

            var response = pipeClient.Send(new ToolMessage { Text = searchString });
            if (response is ToolMessage message)
            {
                return message.Text;
            }

            return "Error occured. Wrong response message type";
        }
    }
}
