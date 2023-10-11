using Global.Network.Common;

namespace Global.Network.Connection.Common
{
    public class ConnectionRoutes
    {
        public const string ServicePath = GlobalNetworkAssetsPaths.Root + "Connection/Service";
        public const string ServiceName = GlobalNetworkAssetsPrefixes.Service + "Connection";
        
        public const string LogsPath = GlobalNetworkAssetsPaths.Root + "Connection/Logs";
        public const string LogsName = GlobalNetworkAssetsPrefixes.Logs + "Connection";
    }
}