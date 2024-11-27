using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rumors.Desktop.Common.Messages.Serialization
{
    public static class SerializationExtension
    {
        private static MessageSerializer _messageSerializer = new MessageSerializer();
        public static string ToXml(this BaseMessage message)
        {
            return _messageSerializer.Serialize(message);
        }

        public static BaseMessage ToMessage(this string message)
        {
            return _messageSerializer.Deserialize(message);
        }
    }
}
