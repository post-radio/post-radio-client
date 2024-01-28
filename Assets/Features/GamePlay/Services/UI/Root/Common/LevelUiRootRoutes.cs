using GamePlay.Common.Paths;

namespace GamePlay.Services.UI.Root.Common
{
    public static class LevelUiRootRoutes
    {
        private const string Paths = GamePlayAssetsPaths.Root + "LevelUiRoot/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "LevelUiRoot";
    }
}