using Global.Common;

namespace Global.System.ScopeDisposer.Common
{
    public static class ScopeDisposerRoutes
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/ScopeDisposer";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "CurrentSceneHandler";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "CurrentSceneHandler";
    }
}