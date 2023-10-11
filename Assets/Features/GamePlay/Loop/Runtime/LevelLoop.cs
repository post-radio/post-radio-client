using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Loop.Logs;
using GamePlay.UI.Runtime;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : IScopeLoadAsyncListener
    {
        public LevelLoop(
            ILevelUiController levelUiController,
            LevelLoopLogger logger)
        {
            _levelUiController = levelUiController;
            _logger = logger;
        }

        private readonly ILevelUiController _levelUiController;
        private readonly LevelLoopLogger _logger;

        public async UniTask OnLoadedAsync()
        {
            _logger.OnLoaded();
            Begin().Forget();
        }

        private async UniTask Begin()
        {
        }
    }
}