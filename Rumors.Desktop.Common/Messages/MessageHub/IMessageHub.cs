using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Messages.MessageHub
{
    public interface IMessageHub
    {
        Task<string> Handle(string message);
        void AddHandler(IMessageHandler handler);
    }
}
