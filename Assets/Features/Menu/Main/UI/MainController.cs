using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Runtime;
using Global.GameLoops.Events;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Global.System.MessageBrokers.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab, IMainInterceptor
    {
        public MainController(
            IMainView view, 
            ISessionJoin join, 
            ISessionCreate create, 
            ILevelCamera camera,
            ILoadingScreen loadingScreen,
            TransitToGameConfig config)
        {
            _view = view;
            _join = join;
            _create = create;
            _camera = camera;
            _loadingScreen = loadingScreen;
            _config = config;
        }

        private readonly IMainView _view;
        private readonly ISessionJoin _join;
        private readonly ISessionCreate _create;
        private readonly ILevelCamera _camera;
        private readonly ILoadingScreen _loadingScreen;
        private readonly TransitToGameConfig _config;

        public RectTransform Transform => _view.Transform;
        
        public async UniTask Activate(CancellationToken cancellation)
        {
            _view.Navigation.Enable();
            _view.Construct(this);
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
            _view.Dispose();
        }

        public void CreateRequested()
        {
            ProcessCreate().Forget();
        }

        public void RandomRequested()
        {
            ProcessRandom().Forget();
        }

        public void WithIdRequested(string id)
        {
            ProcessWithId(id).Forget();
        }

        private async UniTask ProcessCreate()
        {
            var createResult = await _create.Create();

            switch (createResult.Type)
            {
                case SessionCreateResultType.Success:
                    TransitToGame().Forget();
                    break;
                case SessionCreateResultType.Fail:
                    _view.OnError();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private async UniTask ProcessRandom()
        {
            var joinResult = await _join.JoinRandom();

            switch (joinResult.Type)
            {
                case SessionJoinResultType.Success:
                    TransitToGame().Forget();
                    break;
                case SessionJoinResultType.Fail:
                    _view.OnError();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private async UniTask ProcessWithId(string id)
        {
            var joinResult = await _join.Join(id);

            switch (joinResult.Type)
            {
                case SessionJoinResultType.Success:
                    TransitToGame().Forget();
                    break;
                case SessionJoinResultType.Fail:
                    _view.OnError();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async UniTask TransitToGame()
        {
            var progress = 0f;
            var time = 0f;
            var startScale = _camera.Scale;
            var targetScale = _config.TargetCameraScale;
            var startPosition = _camera.Position;
            var targetPosition = _view.TargetCameraPoint.position;
            
            while (progress < 1f)
            {
                time += Time.deltaTime;
                progress = time / _config.Time;
                
                var position = Vector2.Lerp(startPosition, targetPosition, progress);
                var scale = Mathf.Lerp(startScale, targetScale, progress);
                _camera.SetPosition(position);
                _camera.SetScale(scale);
                
                await UniTask.Yield();
            }
            
            _loadingScreen.Show();
            Msg.Publish(new GameRequest());
        }
    }
}