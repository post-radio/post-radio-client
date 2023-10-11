using System.Threading;
using Common.UniversalAnimators.Animations.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.UniversalAnimators.Animations.Implementations.Async
{
    public interface IAsyncAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }

        UniTask Play(CancellationToken cancellationToken);
    }
}