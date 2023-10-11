using Menu.Common.Tasks.Abstract;

namespace Menu.Common.Tasks.Runtime
{
    public class TaskProgress : ITaskProgress
    {
        public TaskProgress(int target, int progress)
        {
            _target = target;
            _current = progress;
        }
        
        private readonly int _target;

        private int _previous;
        private int _current;

        public int Previous => _previous;
        public int Current => _current;
        public int Target => _target;
        public bool IsCompleted => _current >= _target;

        public void Fetch()
        {
            _previous = _current;
        }

        public void OnProgress(int value)
        {
            _current += value;
        }
    }
}