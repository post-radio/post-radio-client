using GamePlay.Common.Paths;

namespace GamePlay.Common.SceneObjects.Common
{
    public class SceneObjectsRoutes
    {
        private const string Paths = GamePlayAssetsPaths.Root + "SceneObjects/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "SceneObjects";

        public const string LogsPath = Paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "SceneObjects";
    }
}