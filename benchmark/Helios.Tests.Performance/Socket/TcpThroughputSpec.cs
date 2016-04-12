using System.Net;

namespace Helios.Tests.Performance.Socket
{
    public class TcpThroughputSpec : SocketThroughputSpec
    {
        public override TransportType TransportType
        {
            get { return TransportType.Tcp; }
        }
    }
}