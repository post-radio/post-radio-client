using Global.Common;

namespace Global.System.Updaters.Common
{
    public static class UpdaterRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/Updater/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Updater";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Updater";
    }
}