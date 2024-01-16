using Global.Common;

namespace Global.Backend.Common
{
    public class BackendRoutes
    {
        private const string Paths = GlobalAssetsPaths.Root + "Backend/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "Backend";
        
        public const string LogsPath = Paths + "Logs";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "Backend";
    }
}