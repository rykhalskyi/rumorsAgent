using MongoDB.Driver;
using Rumors.Desktop.Common.Dto;

namespace Rumors.Desktop.dbConnector
{
    internal class MongoDb
    {
        static string connectionString = "mongodb://dbUser:dbPassword@localhost:27017/rumors";

        public static async Task<string> Save(ConversationDto conversation)
        {
            try
            {
                using (var client = new MongoClient(connectionString))
                {
                    var database = client.GetDatabase("rumors");

                    var collection = database.GetCollection<ConversationDto>("chains");

                    await collection.InsertOneAsync(conversation);
                };

                return "Saved OK";
            }
            catch (Exception ex)
            {
                return $"Db saving error {ex.ToString()}";
            }
        }

        
    }
}
