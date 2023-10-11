using Internal.Services.Loggers.Runtime;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Logs
{
    public class ScenesFlowLogger
    {
        public ScenesFlowLogger(ILogger logger, ScenesFlowLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly ScenesFlowLogSettings _settings;

        public void OnSceneLoad(Scene scene)
        {
            if (_settings.IsAvailable(ScenesFlowLogType.Load) == false)
                return;

            _logger.Log($"Scene {scene.name} is loaded", _settings.LogParameters);
        }

        public void OnSceneUnload(Scene scene)
        {
            if (_settings.IsAvailable(ScenesFlowLogType.Unload) == false)
                return;

            _logger.Log($"Scene {scene.name} is unloaded", _settings.LogParameters);
        }
        
        public void OnSceneUnloadFailed(Scene scene, string exception)
        {
            if (_settings.IsAvailable(ScenesFlowLogType.UnloadFailed) == false)
                return;

            _logger.Error($"Failed to unload scene: {scene} with error: {exception}", _settings.LogParameters);
        }
    }
}