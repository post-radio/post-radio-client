using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.System.Updaters.Runtime.Abstract;

namespace Common.Tools.UniversalAnimators.Updaters.Runtime
{
    public class AnimatorsUpdater : IUpdatable, IAnimatorsUpdater, IScopeAwakeListener
    {
        public AnimatorsUpdater(IUpdater updater)
        {
            _updater = updater;
        }

        private readonly UpdatableAnimatorsList _animators = new();
        private readonly IUpdater _updater;

        public void OnAwake()
        {
            _updater.Add(this);
        }

        public void Register(IUpdatableAnimator animator)
        {
            _animators.Add(animator);
        }

        public void Unregister(IUpdatableAnimator animator)
        {
            _animators.Remove(animator);
        }

        public void OnUpdate(float delta)
        {
            _animators.Fetch();

            foreach (var animator in _animators.List)
                animator.Update(delta);
        }
    }
}