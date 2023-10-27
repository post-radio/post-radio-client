using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.House.Setup;
using GamePlay.Loop.Logs;
using GamePlay.Player.Factory.Runtime;
using GamePlay.Player.Relocation.Runtime;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.UI.Runtime;
using Global.UI.LoadingScreens.Runtime;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    public class LevelLoop : IScopeLoadAsyncListener, IScopeAwakeAsyncListener
    {
        public LevelLoop(
            ILevelUiController levelUiController,
            IPlayerFactory playerFactory,
            IRelocation relocation,
            IHouseSetup houseSetup,
            ILevelCamera camera,
            ILoadingScreen loadingScreen,
            TransitToGameConfig config,
            LevelLoopLogger logger)
        {
            _levelUiController = levelUiController;
            _playerFactory = playerFactory;
            _relocation = relocation;
            _houseSetup = houseSetup;
            _camera = camera;
            _loadingScreen = loadingScreen;
            _config = config;
            _logger = logger;
        }

        private readonly ILevelUiController _levelUiController;
        private readonly IPlayerFactory _playerFactory;
        private readonly IRelocation _relocation;
        private readonly IHouseSetup _houseSetup;
        private readonly ILevelCamera _camera;
        private readonly ILoadingScreen _loadingScreen;
        private readonly TransitToGameConfig _config;
        private readonly LevelLoopLogger _logger;

        public async UniTask OnAwakeAsync()
        {
            _loadingScreen.Show();
            await _houseSetup.Setup();
        }
        
        public async UniTask OnLoadedAsync()
        {
            _logger.OnLoaded();
            Begin().Forget();
        }

        private async UniTask Begin()
        {
            var player = await _playerFactory.CreateLocal();
            var targetCell = await _relocation.GetRandomCell();
            await player.Root.Location.Relocate(targetCell);
            _loadingScreen.Hide();
            await TransitToGame(targetCell.CameraPoint.position);

        }
        
        private async UniTask TransitToGame(Vector2 targetPosition)
        {
            _camera.SetPosition(targetPosition);
            _camera.SetScale(_config.StartCameraScale);
            
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