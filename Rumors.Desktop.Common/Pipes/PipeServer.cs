using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace Rumors.Desktop.Common.Pipes
{
    public class PipeServer
    {
        private readonly string _name;
        private Thread _serverThread;
        private NamedPipeServerStream _serverStream;
        private bool _running;
        private Func<string, Task<string>> _onMessage;
        private ILogger _logger;

        public PipeServer(string name)
        {
            _name = name;
        }

        public void Start(Func<string, Task<string>> onMessage,
            CancellationToken cancellationToken,
            ILogger logger)
        {
            _logger = logger;
            _onMessage = onMessage;
            _running = true;
            _serverThread = new Thread(async()=> await ServerThread(cancellationToken));
            _serverThread.Start();
        }

        public void Stop()
        {
            _running = false;
            _serverStream.Close();

            _serverThread.Join();
        }

        private async Task ServerThread(CancellationToken cancellationToken)
        {
            var attempt = 0;
            while (_running)
            {
                _serverStream =
                        new NamedPipeServerStream(_name, PipeDirection.InOut);
                    await _serverStream.WaitForConnectionAsync(cancellationToken);

                try
                {
                    StreamString streamString = new StreamString(_serverStream);

                    var response = await _onMessage(streamString.ReadString());
                    streamString.WriteString(response);

                    _serverStream.Close();
                }
           
                catch (IOException e)
                {
                    Thread.Sleep(500);
                    attempt++;
                    _running = attempt < 4;
                    _logger.LogError(e, "pipe serer");
                }
                catch (Exception e) 
                {
                    _running = false;
                    _logger.LogError(e, "pipe serer");
                }
            }
        }
    }

    internal class ReadFileToStream
    {
        private string fn;
        private StreamString ss;

        public ReadFileToStream(StreamString str, string filename)
        {
            fn = filename;
            ss = str;
        }

        public void Start()
        {
            string contents = File.ReadAllText(fn);
            ss.WriteString(contents);
        }
    }

}
