using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Messages.MessageHub
{
    public interface IMessageHub
    {
        Task<string> Handle(string message);
        void AddHandler(IMessageHandler handler);

        IMessageHub With(IMessageHandler handler);
    }
}
