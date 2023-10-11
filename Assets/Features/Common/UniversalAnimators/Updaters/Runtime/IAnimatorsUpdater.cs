namespace Common.UniversalAnimators.Updaters.Runtime
{
    public interface IAnimatorsUpdater
    {
        void Register(IUpdatableAnimator animator);
        void Unregister(IUpdatableAnimator animator);
    }
}