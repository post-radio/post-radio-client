using System.Threading;
using Common.UniversalAnimators.Animations.Implementations.Async;
using Common.UniversalAnimators.Animations.Implementations.Looped;
using Common.UniversalAnimators.Animators.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UniversalAnimators.Animators.Native
{
    public class NativeAnimator : IUniversalAnimator
    {
        public NativeAnimator(Animator animator)
        {
            _animator = animator;
        }

        private readonly Animator _animator;

        public void PlayLooped(ILoopedAnimation animation)
        {
            _animator.Play(animation.Data.Name);
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            _animator.Play(animation.Data.Name);
            await UniTask.Yield();
            await UniTask.WaitUntil(IsEnded, PlayerLoopTiming.LastUpdate, cancellationToken);

            bool IsEnded()
            {
                var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName(animation.Data.Name) && stateInfo.normalizedTime < 1.0f)
                    return false;

                return true;
            }
        }
    }
}