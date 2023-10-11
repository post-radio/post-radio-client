using GamePlay.Common.Paths;

namespace GamePlay.Services.UI.Root.Common
{
    public static class LevelUiRootRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "LevelUiRoot/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "LevelUiRoot";
    }
}