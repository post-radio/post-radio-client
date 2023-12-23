namespace Common.Tools.UniversalAnimators.Updaters.Runtime
{
    public interface IAnimatorsUpdater
    {
        void Register(IUpdatableAnimator animator);
        void Unregister(IUpdatableAnimator animator);
    }
}