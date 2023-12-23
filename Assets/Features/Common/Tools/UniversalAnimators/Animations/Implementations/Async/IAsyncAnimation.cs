using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Async
{
    public interface IAsyncAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }

        UniTask Play(CancellationToken cancellationToken);
    }
}