using System;
using Menu.Common.Tasks.Abstract;

namespace Menu.Common.Tasks.Runtime
{
    [Serializable]
    public abstract class TaskCompletionChecker<T> : ITaskCompletionChecker
    {
        public TaskCompletionChecker(ITaskTriggerListenerFactory<T> triggerListenerFactory)
        {
            _triggerListenerFactory = triggerListenerFactory;
        }

        private readonly ITaskTriggerListenerFactory<T> _triggerListenerFactory;

        private IDisposable _listener;

        public event Action Completed;

        public void Construct()
        {
            _listener = _triggerListenerFactory.Create(OnTriggered);
        }

        public void Dispose()
        {
            _listener?.Dispose();
        }

        protected abstract void OnTriggered(T payload);
    }

    [Serializable]
    public class ProgressionTaskCompletionChecker<T> : TaskCompletionChecker<T> where T : IProgressionTask
    {
        public ProgressionTaskCompletionChecker(
            ITaskProgress progress,
            ITaskTriggerListenerFactory<T> triggerListenerFactory) : base(triggerListenerFactory)
        {
            _progress = progress;
        }

        private readonly ITaskProgress _progress;

        protected override void OnTriggered(T payload)
        {
            _progress.OnProgress(payload.Value);
        }
    }
}