using GamePlay.Common.Paths;

namespace GamePlay.Services.LevelCameras.Common
{
    public static class LevelCameraRoutes
    {
        private const string Paths = GamePlayAssetsPaths.Root + "LevelCamera/";

        public const string MenuServicePath = Paths + "Service_Menu";
        public const string MenuServiceName = GamePlayAssetsPrefixes.Service + "Service_Menu";

        public const string LevelServicePath = Paths + "Service_Level";
        public const string LevelServiceName = GamePlayAssetsPrefixes.Service + "Service_Level";
        
        public const string ConfigPath = Paths + "Config";
        public const string ConfigName = GamePlayAssetsPrefixes.Config + "LevelCamera";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "LevelCamera";
    }
}