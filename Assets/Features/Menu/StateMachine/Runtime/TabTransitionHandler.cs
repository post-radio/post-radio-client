using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.StateMachine.Runtime
{
    public class TabTransitionHandler : ITabTransitionHandler
    {
        public TabTransitionHandler(ITabTransitionsConfig config)
        {
            _config = config;
        }

        private readonly ITabTransitionsConfig _config;

        public async UniTask Transit(ITab tab, Vector2 from, Vector2 to)
        {
            var currentTime = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / _config.Time;

                var additionalHeight = _config.MaxHeight * _config.VerticalCurve.Evaluate(progress);
                var position = Vector2.Lerp(from, to, _config.HorizontalCurve.Evaluate(progress));
                position.y += additionalHeight;
                tab.Transform.anchoredPosition = position;

                var angle = _config.MaxRotation * _config.RotationCurve.Evaluate(progress);
                var rotation = Quaternion.Euler(0f, 0f, angle);
                tab.Transform.localRotation = rotation;
                
                await UniTask.Yield();
            }
        }
    }
}