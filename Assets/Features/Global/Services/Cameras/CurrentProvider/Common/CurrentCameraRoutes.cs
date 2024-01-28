using Global.Cameras.Common;
using Global.Common;

namespace Global.Cameras.CurrentProvider.Common
{
    public static class CurrentCameraRoutes
    {
        private const string Paths = GlobalCameraAssetsPaths.Root + "Current/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentCamera";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CurrentCamera";
    }
}