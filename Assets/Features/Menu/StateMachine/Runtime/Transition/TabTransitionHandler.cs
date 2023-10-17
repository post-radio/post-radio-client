using Cysharp.Threading.Tasks;
using GamePlay.Services.LevelCameras.Runtime;
using UnityEngine;

namespace Menu.StateMachine.Runtime.Transition
{
    public class TabTransitionHandler : ITabTransitionHandler
    {
        public TabTransitionHandler(ITabTransitionsConfig config, ILevelCamera camera)
        {
            _config = config;
            _camera = camera;
        }

        private readonly ITabTransitionsConfig _config;
        private readonly ILevelCamera _camera;

        public async UniTask Transit(Vector2 to)
        {
            var currentTime = 0f;
            var progress = 0f;
            var from = _camera.Position;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / _config.Time;

                var position = Vector2.Lerp(from, to, _config.HorizontalCurve.Evaluate(progress));
                _camera.SetPosition(position);

                await UniTask.Yield();
            }
        }
    }
}