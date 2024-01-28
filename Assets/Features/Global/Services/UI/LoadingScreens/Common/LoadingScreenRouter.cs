using Global.Common;

namespace Global.UI.LoadingScreens.Common
{
    public static class LoadingScreenRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "UI/LoadingScreen/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "LoadingScreen";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "LoadingScreen";
    }
}