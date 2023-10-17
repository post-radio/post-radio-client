using UnityEngine;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace GamePlay.Services.LevelCameras.Logs
{
    public class LevelCameraLogger
    {
        public LevelCameraLogger(ILogger logger, LevelCameraLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly LevelCameraLogSettings _settings;

        public void OnMove(Vector2 position)
        {
            if (_settings.IsAvailable(LevelCameraLogType.Move) == false)
                return;

            _logger.Log($"Move to: {position}", _settings.LogParameters);
        }

        public void OnScale(float size)
        {
            if (_settings.IsAvailable(LevelCameraLogType.Scale) == false)
                return;

            _logger.Log($"Scale to: {size}", _settings.LogParameters);
        }
    }
}