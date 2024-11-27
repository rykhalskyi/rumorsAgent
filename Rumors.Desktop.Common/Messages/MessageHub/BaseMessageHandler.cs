using Rumors.Desktop.Common.Messages.Serialization;
using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Messages.MessageHub
{
    public abstract class BaseMessageHandler<T> : IMessageHandler where T:BaseMessage
    {
        public bool CanHandle(BaseMessage message)
        {
            return message.GetType() == typeof(T);
        }

        public async Task<string> Handle(BaseMessage message)
        {
            if (message is T concreteMessage)
            {

                try
                {
                    return (await Process(concreteMessage)).ToXml();
                }
                catch (System.Exception ex) 
                {
                    var errorMessage = new SimpleResponseMessage
                    {
                        Message = $"Server error: {ex.Message}",
                        Successful = false
                        
                    };
                    return errorMessage.ToXml();
                }
            }
                
            return null;
        }

        protected abstract Task<BaseMessage> Process(T message);
   
   
    }
}
