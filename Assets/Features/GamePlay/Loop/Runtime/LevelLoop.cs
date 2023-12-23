using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.House.Setup;
using GamePlay.Loop.Logs;
using GamePlay.Player.Services.Factory.Runtime;
using GamePlay.Player.Services.Relocation.Runtime;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.UI.Runtime;
using Global.Cameras.GlobalCameras.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Nova.InputManagers.Abstract;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : IScopeLoadAsyncListener, IScopeAwakeAsyncListener, IScopeDisableListener
    {
        public LevelLoop(
            ILevelUiController levelUiController,
            IPlayerFactory playerFactory,
            IRelocation relocation,
            IHouseSetup houseSetup,
            ILevelCamera camera,
            ILoadingScreen loadingScreen,
            ICameraMover cameraMover,
            IGlobalCamera globalCamera,
            IUIInputManager uiInputManager,
            TransitToGameConfig config,
            LevelLoopLogger logger)
        {
            _levelUiController = levelUiController;
            _playerFactory = playerFactory;
            _relocation = relocation;
            _houseSetup = houseSetup;
            _camera = camera;
            _loadingScreen = loadingScreen;
            _cameraMover = cameraMover;
            _globalCamera = globalCamera;
            _UIInputManager = uiInputManager;
            _config = config;
            _logger = logger;
        }

        private readonly ILevelUiController _levelUiController;
        private readonly IPlayerFactory _playerFactory;
        private readonly IRelocation _relocation;
        private readonly IHouseSetup _houseSetup;
        private readonly ILevelCamera _camera;
        private readonly ILoadingScreen _loadingScreen;
        private readonly ICameraMover _cameraMover;
        private readonly IGlobalCamera _globalCamera;
        private readonly IUIInputManager _UIInputManager;
        private readonly TransitToGameConfig _config;
        private readonly LevelLoopLogger _logger;

        public async UniTask OnAwakeAsync()
        {
            _UIInputManager.SetCamera(_camera.Camera);
            _loadingScreen.Show();
            await _houseSetup.Setup();
        }
        
        public async UniTask OnLoadedAsync()
        {
            _logger.OnLoaded();
            Begin().Forget();
        }
        
        public void OnDisabled()
        {
            _UIInputManager.RemoveCamera(_camera.Camera);
            _cameraMover.Disable();   
        }

        private async UniTask Begin()
        {
            var player = await _playerFactory.CreateLocal();
            var targetCell = await _relocation.GetRandomCell();
            await player.Root.Location.Relocate(targetCell);
            _loadingScreen.Hide();
            _camera.SetPosition(targetCell.Transform.position);
            _camera.SetScale(_config.StartCameraScale);
            _camera.Enable();
            _globalCamera.Disable();
            await TransitToGame();
            
            _cameraMover.Enable();
        }
        
        private async UniTask TransitToGame()
        {
            var progress = 0f;
            var time = 0f;
            var startScale = _camera.Scale;
            var targetScale = _config.TargetCameraScale;
            
            while (progress < 1f)
            {
                time += Time.deltaTime;
                progress = time / _config.Time;
                
                var scale = Mathf.Lerp(startScale, targetScale, progress);
                _camera.SetScale(scale);
                
                await UniTask.Yield();
            }
        }
    }
}