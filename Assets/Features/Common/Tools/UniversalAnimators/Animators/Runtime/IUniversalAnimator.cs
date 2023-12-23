using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;
using Cysharp.Threading.Tasks;

namespace Common.Tools.UniversalAnimators.Animators.Runtime
{
    public interface IUniversalAnimator
    {
        void PlayLooped(ILoopedAnimation animation);
        UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken);
    }
}