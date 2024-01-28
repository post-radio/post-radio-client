using Global.Common;

namespace Global.GameLoops.Common
{
    public static class GameLoopRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "GameLoop/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "GameLoop";
        
        public const string MockPath = Paths + "Mock";
        public const string MockName = GlobalAssetsPrefixes.Service + "GameLoop_Mock";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "GameLoop";
    }
}