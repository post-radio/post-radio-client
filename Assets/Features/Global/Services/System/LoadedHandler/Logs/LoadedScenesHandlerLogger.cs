using Internal.Services.Loggers.Runtime;

namespace Global.System.LoadedHandler.Logs
{
    public class LoadedScenesHandlerLogger
    {
        public LoadedScenesHandlerLogger(ILogger logger, LoadedScenesHandlerLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly LoadedScenesHandlerLogSettings _settings;

        public void OnLoaded(int scenesCount)
        {
            if (_settings.IsAvailable(LoadedScenesHandlerLogType.Load) == false)
                return;

            _logger.Log($"Loaded {scenesCount} scenes", _settings.LogParameters);
        }

        public void OnUnload(int scenesCount)
        {
            if (_settings.IsAvailable(LoadedScenesHandlerLogType.Unload) == false)
                return;

            _logger.Log($"Unloading {scenesCount} scenes", _settings.LogParameters);
        }

        public void OnNoCurrentSceneError()
        {
            if (_settings.IsAvailable(LoadedScenesHandlerLogType.NoCurrentSceneError) == false)
                return;

            _logger.Log("Unloading failed, no current scene assigned", _settings.LogParameters);
        }

        public void OnUnloadingFinalized()
        {
            if (_settings.IsAvailable(LoadedScenesHandlerLogType.FinalizeUnloading) == false)
                return;

            _logger.Log("Scenes unloading finalized", _settings.LogParameters);
        }
    }
}