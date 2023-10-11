using GamePlay.Common.Paths;

namespace GamePlay.Common.SceneObjects.Common
{
    public class SceneObjectsRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "SceneObjects/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "SceneObjects";

        public const string LogsPath = _paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "SceneObjects";
    }
}