using Menu.Common.Tasks.Abstract;
using UnityEngine;

namespace Menu.Common.Tasks.Runtime
{
    public class TaskFactory : ScriptableObject, ITaskFactory
    {
        [SerializeField] private int _target;
        [SerializeReference] private string _key;
        [SerializeReference] private ITaskCompletionChecker _completionChecker;
        [SerializeReference] private ITaskCompletionProcessor _completionProcessor;
        [SerializeField] private TaskData _data;
        
        public string Key => _key;

        public IGoalTask Create(int currentProgress)
        {
            var progress = new TaskProgress(_target, currentProgress);
            _completionProcessor.Construct(_completionChecker);
            _completionProcessor.Enable();
            return new GoalTask(_data, _completionChecker, _completionProcessor, progress);
        }
    }
}