using GamePlay.Common.Paths;

namespace GamePlay.Services.LevelCameras.Common
{
    public static class LevelCameraRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "LevelCamera/";

        public const string MenuServicePath = _paths + "Service_Menu";
        public const string MenuServiceName = GamePlayAssetsPrefixes.Service + "Service_Menu";

        public const string LevelServicePath = _paths + "Service_Level";
        public const string LevelServiceName = GamePlayAssetsPrefixes.Service + "Service_Level";
        
        public const string ConfigPath = _paths + "Config";
        public const string ConfigName = GamePlayAssetsPrefixes.Config + "LevelCamera";

        public const string LogsPath = _paths + "Logger";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "LevelCamera";
    }
}