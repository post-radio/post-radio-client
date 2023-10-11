namespace Global.Network.Connection.Runtime
{
    public readonly struct ConnectionConfig
    {
        public ConnectionConfig(string address, string protocol, ushort port)
        {
            Address = address;
            Protocol = protocol;
            Port = port;
        }

        public readonly string Address;
        public readonly string Protocol;
        public readonly ushort Port;
    }
}