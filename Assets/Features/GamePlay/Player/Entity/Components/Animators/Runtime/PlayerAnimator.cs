using System.Threading;
using Common.UniversalAnimators.Animations.Implementations.Async;
using Common.UniversalAnimators.Animations.Implementations.Looped;
using Common.UniversalAnimators.Animators.Native;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Animators.Runtime
{
    public class PlayerAnimator : IPlayerAnimator
    {
        public PlayerAnimator(Animator animator)
        {
            _nativeAnimator = new NativeAnimator(animator);
        }

        private readonly NativeAnimator _nativeAnimator;
        
        public void PlayLooped(ILoopedAnimation animation)
        {
            _nativeAnimator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            await _nativeAnimator.PlayAsync(animation, cancellationToken);
        }
    }
}