using Common.Tools.UniversalAnimators.Animations.Abstract;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Looped
{
    public interface ILoopedAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }
        void Play();
    }
}