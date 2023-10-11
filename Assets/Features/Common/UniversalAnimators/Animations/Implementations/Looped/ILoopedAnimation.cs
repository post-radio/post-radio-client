using Common.UniversalAnimators.Animations.Abstract;

namespace Common.UniversalAnimators.Animations.Implementations.Looped
{
    public interface ILoopedAnimation : IUpdatableAnimation
    {
        AnimationData Data { get; }
        void Play();
    }
}