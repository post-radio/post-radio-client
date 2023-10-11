using System.Threading;
using Common.UniversalAnimators.Animations.Abstract;
using Common.UniversalAnimators.Animations.Implementations.Async;
using Common.UniversalAnimators.Animations.Implementations.Looped;
using Common.UniversalAnimators.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UniversalAnimators.Animators.Runtime
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