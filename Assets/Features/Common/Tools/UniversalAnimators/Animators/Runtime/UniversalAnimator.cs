using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animators.Runtime
{
    public class UniversalAnimator : IUniversalAnimator, IUpdatableAnimator
    {
        public UniversalAnimator(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        private readonly SpriteRenderer _spriteRenderer;

        private IUpdatableAnimation _current;

        public void Update(float delta)
        {
            _spriteRenderer.sprite = _current?.Update(delta);
        }

        public void PlayLooped(ILoopedAnimation animation)
        {
            _current = animation;
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            _current = animation;
            _spriteRenderer.sprite = _current?.Update(0f);
            await animation.Play(cancellationToken);
        }
    }
}