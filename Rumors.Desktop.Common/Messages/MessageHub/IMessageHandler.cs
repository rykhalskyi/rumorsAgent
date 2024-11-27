using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Messages.MessageHub
{
    public interface IMessageHandler
    {
        Task<string> Handle(BaseMessage message);
        bool CanHandle(BaseMessage message);
    }
}