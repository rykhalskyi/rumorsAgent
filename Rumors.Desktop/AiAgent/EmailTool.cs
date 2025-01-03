using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Pipes;
using Rumors.Desktop.dbConnector;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        [KernelFunction("get_email_chain")]
        [Description("Retrieves email chain (conversation). This chain can be used as history of topic of conversation" +
            "input arguments: emailId - ID of email, whise chain should be retrieved")]
        [return: Description("json of whole conversation whit contains emails chain as array")]
        public string GetEmailChain(string emailId)
        {
            var pipeClient = ApplicationEntryPoint.ServiceProvider.GetService<PipeClient>()!;
            var response = pipeClient.Send(new GetConversationMessage { EmailEntityId = emailId });
            if (response is GetConversationMessage message)
            {
                var serialized = JsonSerializer.Serialize(message.Conversation);
                Debug.WriteLine($"** >> {serialized}");
                return serialized;
            }

            return "Error occured. Wrong response message type";
        }

        //[KernelFunction("open_email")]
        //[Description("opens email with specific emailId in the outlook"+
        //    "input argument: emailId Id of the email")]
        //[return: Description("string with execution result. don't show it to user unless it's an error")]
        //public string OpenEmail(string emailId)
        //{
        //    var pipeClient = ApplicationEntryPoint.ServiceProvider.GetService<PipeClient>()!;
        //    var response = pipeClient.Send(new OpenEmailMessage { EmailId = emailId });
        //    if (response is SimpleResponseMessage message)
        //    {
        //        return message.Message;
        //    }

        //    return "Error occured. Wrong response message type";
        //}

        [KernelFunction("save_email_chain")]
        [Description("Save email chain (conversation) to the storage" +
            "input arguments: chainId - ID of chain (conversation),"+
            "json - json string with array of email objects \"Emails\" : [ list_of_emails ]"+
            "format of each list element: {\"EmailId\" : \"email_id\", \"Subject\" : \"subject_of_email\", \"From\" : \"senders_email_address\", \"To\" : \"recepient_email_address\", \"CreationTime\": \"datetime_of_email\", \"Body\" : \"content_of_email\"}" +
            "each element of array should contain all fields. if you has no information leave this fields blank.")]
            
        [return: Description("string with execution result. don't show it to user unless it's an error")]
        public string SaveChain(string chainId, string json)
        {
            try
            {
                var conversation = JsonSerializer.Deserialize<ConversationDto>(json);
                if (conversation == null) return ("input json is invalid. can not parse it into object");

                conversation.ConversationId = chainId;
                return MongoDb.Save(conversation).Result;
            }
            catch (Exception ex)
            {
                return $"Saving Fatal Error: {ex.ToString}";
            }
        }
    }
}

