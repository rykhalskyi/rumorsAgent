using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.Serialization;
using System;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Pipes
{
    public class PipeClient
    {
        private readonly string _pipeName;
        private readonly Action<Exception> _onError;

        public PipeClient(string pipeName, Action<Exception> onError)
        {
            _pipeName = pipeName;
            _onError = onError;
        }

        public BaseMessage Send(BaseMessage message)
        {
            var result = "";
            try
            {
                var pipeClient = new NamedPipeClientStream(".", _pipeName,
                    PipeDirection.InOut, PipeOptions.None,
                    TokenImpersonationLevel.Impersonation);

                var streamString = new StreamString(pipeClient);
                pipeClient.Connect(250);

                streamString.WriteString(message.ToXml());

                result = streamString.ReadString();

                pipeClient.Close();

                return result.ToMessage();
            }
            catch(Exception ex)
            {
                _onError(ex);
                return null;
            }
   
        }
    }
}
