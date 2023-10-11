using System.Threading;
using Common.UniversalAnimators.Animations.Implementations.Async;
using Common.UniversalAnimators.Animations.Implementations.Looped;
using Cysharp.Threading.Tasks;

namespace Common.UniversalAnimators.Animators.Runtime
{
    public interface IUniversalAnimator
    {
        void PlayLooped(ILoopedAnimation animation);
        UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken);
    }
}