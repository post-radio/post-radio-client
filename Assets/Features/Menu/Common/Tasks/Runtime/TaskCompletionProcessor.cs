using System;
using Global.System.MessageBrokers.Runtime;
using Menu.Common.Tasks.Abstract;
using UnityEngine;

namespace Menu.Common.Tasks.Runtime
{
    public abstract class TaskCompletionProcessor : ITaskCompletionProcessor
    {
        private ITaskCompletionChecker _completionChecker;

        public void Construct(ITaskCompletionChecker completionChecker)
        {
            _completionChecker = completionChecker;
        }

        public void Enable()
        {
            _completionChecker.Completed += OnCompleted;
        }

        public void Dispose()
        {
            _completionChecker.Completed -= OnCompleted;
        }

        protected abstract void OnCompleted();
    }

    [Serializable]
    public class PublishTaskCompletionProcessor<T> : TaskCompletionProcessor where T : new()
    {
        [SerializeField] private T _message;
        
        protected override void OnCompleted()
        {
            Msg.Publish(_message); 
        }
    }
}