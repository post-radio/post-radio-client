using Common.Architecture.Scopes.Runtime;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.System.ScopeDisposer.Logs;
using Internal.Services.Scenes.Abstract;

namespace Global.System.ScopeDisposer.Runtime
{
    public class ScopeDisposer : IScopeDisposer
    {
        public ScopeDisposer(
            ISceneUnloader sceneUnload,
            ScopeDisposerLogger logger)
        {
            _logger = logger;
            _sceneUnload = sceneUnload;
        }

        private readonly ScopeDisposerLogger _logger;

        private readonly ISceneUnloader _sceneUnload;

        public async UniTask Unload(IScopeLoadResult scopeLoadResult)
        {
            _logger.OnUnload(scopeLoadResult.Scenes.Count);

            await scopeLoadResult.Callbacks[CallbackStage.Dispose].Run();
            await _sceneUnload.Unload(scopeLoadResult.Scenes);

            _logger.OnUnloadingFinalized();
        }
    }
}