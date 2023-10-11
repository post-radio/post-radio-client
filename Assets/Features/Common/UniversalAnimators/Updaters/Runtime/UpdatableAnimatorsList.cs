using System.Collections.Generic;

namespace Common.UniversalAnimators.Updaters.Runtime
{
    public class UpdatableAnimatorsList
    {
        private readonly List<IUpdatableAnimator> _addQueue = new();
        private readonly List<IUpdatableAnimator> _list = new();

        private readonly List<IUpdatableAnimator> _removeQueue = new();

        public IReadOnlyList<IUpdatableAnimator> List => _list;

        public void Add(IUpdatableAnimator updatable)
        {
            _addQueue.Add(updatable);
        }

        public void Remove(IUpdatableAnimator updatable)
        {
            _removeQueue.Add(updatable);
        }

        public void Fetch()
        {
            FetchAdd();
            FetchRemove();
        }

        private void FetchAdd()
        {
            _list.AddRange(_addQueue);
            _addQueue.Clear();
        }

        private void FetchRemove()
        {
            foreach (var removed in _removeQueue)
                _list.Remove(removed);

            _removeQueue.Clear();
        }
    }
}