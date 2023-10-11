using System;
using Menu.Common.Tasks.Abstract;
using UnityEngine;

namespace Menu.Common.Tasks.Runtime
{
    [Serializable]
    public abstract class TaskCompletionDefinition<T, T1> : ITaskCompletionDefinition
        where T : IProgressionTask
        where T1 : new()
    {
        [SerializeField] private ProgressionTaskCompletionChecker<T> _completionChecker;
        [SerializeField] private PublishTaskCompletionProcessor<T1> _completionProcessor;

        public ITaskCompletionChecker CompletionChecker => _completionChecker;
        public ITaskCompletionProcessor CompletionProcessor => _completionProcessor;
    }

    public interface ITaskCompletionDefinition
    {
        public ITaskCompletionChecker CompletionChecker { get; }
        public ITaskCompletionProcessor CompletionProcessor { get; }
    }
}