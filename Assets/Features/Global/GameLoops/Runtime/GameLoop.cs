using System;
using Common.Architecture.ScopeLoaders.Factory;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Cysharp.Threading.Tasks;
using GamePlay.Config.Runtime;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.GameLoops.Events;
using Global.Network.Connection.Runtime;
using Global.System.LoadedHandler.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Overlays.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Abstract;
using Menu.Config.Runtime;
using VContainer.Unity;

namespace Global.GameLoops.Runtime
{
    public class GameLoop : IScopeLoadAsyncListener, IScopeSwitchListener
    {
        public GameLoop(
            LifetimeScope scope,
            IScopeLoaderFactory scopeLoaderFactory,
            ILoadingScreen loadingScreen,
            IGlobalCamera globalCamera,
            ILoadedScenesHandler loadedScenesHandler,
            ICurrentCamera currentCamera,
            IOptions options,
            IConnection connection,
            IGlobalExceptionController globalException,
            LevelScopeConfig levelScope,
            MenuScopeConfig menuScope)
        {
            _levelScope = levelScope;
            _menuScope = menuScope;
            _scope = scope;
            _scopeLoaderFactory = scopeLoaderFactory;
            _loadingScreen = loadingScreen;
            _globalCamera = globalCamera;
            _loadedScenesHandler = loadedScenesHandler;
            _currentCamera = currentCamera;
            _options = options;
            _connection = connection;
            _globalException = globalException;
        }

        private readonly ICurrentCamera _currentCamera;
        private readonly IOptions _options;
        private readonly IConnection _connection;
        private readonly IGlobalExceptionController _globalException;
        private readonly ILoadedScenesHandler _loadedScenesHandler;
        private readonly IGlobalCamera _globalCamera;

        private readonly ISceneLoader _loader;
        private readonly ILoadingScreen _loadingScreen;

        private readonly LifetimeScope _scope;
        private readonly IScopeLoaderFactory _scopeLoaderFactory;

        private readonly LevelScopeConfig _levelScope;
        private readonly MenuScopeConfig _menuScope;

        private IDisposable _restartListener;
        private IDisposable _enterGameListener;
        private IDisposable _enterMenuListener;

        public void OnEnabled()
        {
            _restartListener = Msg.Listen<GameRestartRequest>(OnRestartRequested);
            _enterGameListener = Msg.Listen<GameRequest>(OnLevelRequest);
            _enterMenuListener = Msg.Listen<MenuRequest>(OnMenuRequest);
        }

        public void OnDisabled()
        {
            _restartListener.Dispose();
            _enterGameListener.Dispose();
            _enterMenuListener.Dispose();
        }
        
        public async UniTask OnLoadedAsync()
        {
            ProcessGameStart().Forget();
        }

        private void OnRestartRequested(GameRestartRequest request)
        {
            ProcessGameStart().Forget();
        }

        private void OnLevelRequest(GameRequest request)
        {
            LoadScene(_levelScope).Forget();
        }
        
        private void OnMenuRequest(MenuRequest request)
        {
            LoadScene(_menuScope).Forget();
        }
        
        private async UniTask ProcessGameStart()
        {
            var connectionResult = await _connection.Connect();

            if (connectionResult == ConnectionResultType.Fail)
            {
                _globalException.Show();
                return;
            }
            
            await LoadScene(_menuScope);
            _loadingScreen.HideGameLoading();
        }

        private async UniTask LoadScene(IScopeConfig config)
        {
            _globalCamera.Enable();
            _currentCamera.SetCamera(_globalCamera.Camera);

            var scopeLoader = _scopeLoaderFactory.Create(config, _scope);
            var scopeLoadResult = await scopeLoader.Load();
            await scopeLoadResult.Callbacks[CallbackStage.Construct].Run();
            
            var unload = _loadedScenesHandler.Unload();

            await unload;
            await _loadedScenesHandler.FinalizeUnloading();

            _loadedScenesHandler.OnLoaded(scopeLoadResult);
            
            await scopeLoadResult.Callbacks[CallbackStage.SetupComplete].Run();
        }
    }
}