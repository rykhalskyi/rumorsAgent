namespace Rumors.Desktop.Common.Messages.Serialization
{
    public interface IMessageSerializer
    {
        BaseMessage Deserialize(string xml);
        string Serialize(BaseMessage message);
    }
}