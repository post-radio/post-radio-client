using Global.Cameras.Common;
using Global.Common;

namespace Global.Cameras.Utils.Common
{
    public static class CameraUtilsRoutes
    {
        private const string Paths = GlobalCameraAssetsPaths.Root + "Utils/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CameraUtils";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CameraUtiles";
    }
}