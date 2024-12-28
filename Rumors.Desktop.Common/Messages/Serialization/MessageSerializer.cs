using System;
using System.IO;
using System.Xml.Serialization;

namespace Rumors.Desktop.Common.Messages.Serialization
{
    public class MessageSerializer : IMessageSerializer
    {
        private readonly XmlSerializer _xmlSerializer;
        private static MessageSerializer _instance;

        public MessageSerializer()
        {
            _xmlSerializer = new XmlSerializer(typeof(BaseMessage), GetSupportedTypes());
        }

        public string Serialize(BaseMessage message)
        {
            using (var writer = new StringWriter())
            {
                _xmlSerializer.Serialize(writer, message);
                return writer.ToString();
            }
        }

        public BaseMessage Deserialize(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                return (BaseMessage)_xmlSerializer.Deserialize(reader);
            }
        }

        private Type[] GetSupportedTypes()
        {
            return new Type[] {
                typeof(SimpleResponseMessage),
                typeof(ChatMessage),
                typeof(ToolMessage),
                typeof(SearchMessage),
                typeof(GetConversationMessage)
            };
        }
    }
}
