using Global.Network.Common;

namespace Global.Network.Session.Common
{
    public class SessionRoutes
    {
        private const string _root = GlobalNetworkAssetsPaths.Root;

        public const string ServicePath = GlobalNetworkAssetsPaths.Root + "Session/Service";
        public const string ServiceName = GlobalNetworkAssetsPrefixes.Service + "Session";
        
        public const string LogsPath = GlobalNetworkAssetsPaths.Root + "Session/Logs";
        public const string LogsName = GlobalNetworkAssetsPrefixes.Logs + "Session";
    }
}