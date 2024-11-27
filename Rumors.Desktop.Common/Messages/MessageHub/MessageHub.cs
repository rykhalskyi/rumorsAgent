using Microsoft.Extensions.Logging;
using Rumors.Desktop.Common.Messages.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Messages.MessageHub
{
    public class MessageHub : IMessageHub
    {
        public readonly IMessageSerializer _messageSerializer;
        private readonly List<IMessageHandler> _handlers = new List<IMessageHandler>();
        private readonly ILogger _logger;

        public MessageHub(IMessageSerializer messageSerializer)
        {
            _messageSerializer = messageSerializer;
        }
                

        public void AddHandler(IMessageHandler handler)
        {
            if (!_handlers.Contains(handler))
            {
                _handlers.Add(handler);
            }
        }

        public async Task<string> Handle(string message)
        {
            var deserializedMessage = _messageSerializer.Deserialize(message);
            if (deserializedMessage == null)
            {
                _logger.LogWarning("Unsupported message", message);
                return string.Empty;
            }

            return await HandleInternal(deserializedMessage);
        }

        private async Task<string> HandleInternal(BaseMessage message)
        {
            var result = string.Empty;
            var handler = _handlers.FirstOrDefault(i=> i.CanHandle(message));
            if (handler != null)
            {
              
               result = await handler.Handle(message);
            }

            return result;
        }
    }
}
