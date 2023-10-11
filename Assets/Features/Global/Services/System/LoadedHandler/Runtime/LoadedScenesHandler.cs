using Common.Architecture.ScopeLoaders.Runtime;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.System.LoadedHandler.Logs;
using Global.System.ResourcesCleaners.Runtime;
using Internal.Services.Scenes.Abstract;

namespace Global.System.LoadedHandler.Runtime
{
    public class LoadedScenesHandler : ILoadedScenesHandler
    {
        public LoadedScenesHandler(
            ISceneUnloader sceneUnload,
            IResourcesCleaner resourcesCleaner,
            LoadedScenesHandlerLogger logger)
        {
            _logger = logger;
            _sceneUnload = sceneUnload;
            _resourcesCleaner = resourcesCleaner;
        }

        private readonly LoadedScenesHandlerLogger _logger;

        private readonly IResourcesCleaner _resourcesCleaner;
        private readonly ISceneUnloader _sceneUnload;

        private IScopeLoadResult _current;

        public void OnLoaded(IScopeLoadResult loaded)
        {
            _current = loaded;

            _logger.OnLoaded(_current.Scenes.Count);
        }

        public async UniTask Unload()
        {
            if (_current == null)
            {
                _logger.OnNoCurrentSceneError();
                return;
            }

            _logger.OnUnload(_current.Scenes.Count);

            await _current.Callbacks[CallbackStage.Dispose].Run();

            await _sceneUnload.Unload(_current.Scenes);
        }

        public async UniTask FinalizeUnloading()
        {
            await _resourcesCleaner.CleanUp();

            _logger.OnUnloadingFinalized();
        }
    }
}