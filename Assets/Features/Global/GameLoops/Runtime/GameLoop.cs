using Common.Architecture.ScopeLoaders.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.System.LoadedHandler.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Menu.Config.Runtime;
using VContainer.Unity;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : IScopeLoadAsyncListener
    {
        public GameLoop(
            LifetimeScope scope,
            IScopeLoaderFactory scopeLoaderFactory,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ILoadedScenesHandler loadedScenesHandler,
            ICurrentCamera currentCamera,
            IOptions options,
            LevelConfig level,
            MenuConfig menu)
        {
            _level = level;
            _menu = menu;
            _scope = scope;
            _scopeLoaderFactory = scopeLoaderFactory;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _loadedScenesHandler = loadedScenesHandler;
            _currentCamera = currentCamera;
            _options = options;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly IOptions _options;
        private readonly ILoadedScenesHandler _loadedScenesHandler;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;

        private readonly LifetimeScope _scope;
        private readonly IScopeLoaderFactory _scopeLoaderFactory;

        private readonly LevelConfig _level;
        private readonly MenuConfig _menu;

        public async UniTask OnLoadedAsync()
        {
            LoadScene(_menu).Forget();
        }

        private async UniTaskVoid LoadScene(IScopeConfig config)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            _loadingScreen.Show();

            var scopeLoader = _scopeLoaderFactory.Create(config, _scope);
            var scopeLoadResult = await scopeLoader.Load();
            await scopeLoadResult.Callbacks[CallbackStage.Construct].Run();
            
            var unload = _loadedScenesHandler.Unload();

            await unload;
            await _loadedScenesHandler.FinalizeUnloading();

            _loadedScenesHandler.OnLoaded(scopeLoadResult);
            _globalCamera.Disable();
            _loadingScreen.Hide();
            
            await scopeLoadResult.Callbacks[CallbackStage.SetupComplete].Run();
        }
    }
}