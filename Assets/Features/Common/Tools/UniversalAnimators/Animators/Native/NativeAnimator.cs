using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Animators.Runtime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animators.Native
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
            
            await UniTask.WaitUntil(IsStarted, PlayerLoopTiming.LastUpdate, cancellationToken);
            await UniTask.WaitUntil(IsEnded, PlayerLoopTiming.LastUpdate, cancellationToken);

            bool IsStarted()
            {
                var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName(animation.Data.Name) == false)
                    return false;

                return true;
            }
            
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