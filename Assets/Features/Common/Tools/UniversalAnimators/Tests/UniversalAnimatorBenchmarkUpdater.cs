using System.Collections.Generic;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Tests
{
    public class UniversalAnimatorBenchmarkUpdater : MonoBehaviour, IAnimatorsUpdater
    {
        private readonly List<IUpdatableAnimator> _animators = new();

        public void Register(IUpdatableAnimator animator)
        {
            _animators.Add(animator);
        }

        public void Unregister(IUpdatableAnimator animator)
        {
            _animators.Remove(animator);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            
            foreach (var animator in _animators)
                animator.Update(delta);
        }
    }
}