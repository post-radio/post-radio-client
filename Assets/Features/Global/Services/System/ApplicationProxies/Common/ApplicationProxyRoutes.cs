using Global.Common;

namespace Global.System.ApplicationProxies.Common
{
    public static class ApplicationProxyRoutes
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/ApplicationProxy/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "ApplicationProxy";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "ApplicationProxy";
    }
}