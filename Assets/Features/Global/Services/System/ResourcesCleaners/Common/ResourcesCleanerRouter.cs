using Global.Common;

namespace Global.System.ResourcesCleaners.Common
{
    public class ResourcesCleanerRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/ResourcesCleaner/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "ResourcesCleaner";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "ResourcesCleaner";
    }
}