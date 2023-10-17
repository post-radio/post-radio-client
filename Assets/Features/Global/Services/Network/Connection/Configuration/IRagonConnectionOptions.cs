using Ragon.Client.Unity;

namespace Global.Network.Connection.Configuration
{
    public interface IRagonConnectionOptions
    {
        RagonConnectionType Type { get; }
        public string Address { get; }
        public string Protocol { get; }
        public ushort Port { get; }
        public int Rate { get; }
    }
}