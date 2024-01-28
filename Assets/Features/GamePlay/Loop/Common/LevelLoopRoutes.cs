using GamePlay.Common.Paths;

namespace GamePlay.Loop.Common
{
    public static class LevelLoopRoutes
    {
        private const string Paths = GamePlayAssetsPaths.Root + "Loop/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Loop";

        public const string LogsPath = Paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "Loop";
    }
}