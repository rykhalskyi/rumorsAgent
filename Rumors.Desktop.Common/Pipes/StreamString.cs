using System;
using System.IO;
using System.Text;

namespace Rumors.Desktop.Common.Pipes
{
    public class StreamString
    {
        private Stream _ioStream;
        private UnicodeEncoding _streamEncoding;

        public StreamString(Stream ioStream)
        {
            this._ioStream = ioStream;
            _streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            var lenBytes = new byte[4];
            _ioStream.Read(lenBytes, 0, lenBytes.Length);

            var len = BitConverter.ToInt32(lenBytes, 0);
            byte[] inBuffer = new byte[len];
            _ioStream.Read(inBuffer, 0, len);

            return _streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            var outBuffer = _streamEncoding.GetBytes(outString);
            var len = outBuffer.Length;
            
            //4 bytes
            var lenBytes = BitConverter.GetBytes(len);
            _ioStream.Write(lenBytes, 0, lenBytes.Length);

            _ioStream.Write(outBuffer, 0, len);
            _ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }

}
