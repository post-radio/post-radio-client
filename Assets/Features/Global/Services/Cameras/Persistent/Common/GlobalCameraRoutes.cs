using Global.Cameras.Common;
using Global.Common;

namespace Global.Cameras.Persistent.Common
{
    public static class GlobalCameraRoutes
    {
        private const string Paths = GlobalCameraAssetsPaths.Root + "Global/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "GlobalCamera";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "GlobalCamera";
    }
}