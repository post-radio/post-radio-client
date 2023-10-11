using Menu.Common.Tasks.Abstract;

namespace Menu.Common.Tasks.Runtime
{
    public class GoalTask : IGoalTask
    {
        public GoalTask(
            ITaskData data,
            ITaskCompletionChecker completionChecker,
            ITaskCompletionProcessor completionProcessor,
            ITaskProgress progress)
        {
            Data = data;
            CompletionChecker = completionChecker;
            CompletionProcessor = completionProcessor;
            Progress = progress;
        }

        public ITaskData Data { get; }
        public ITaskCompletionChecker CompletionChecker { get; }
        public ITaskCompletionProcessor CompletionProcessor { get; }
        public ITaskProgress Progress { get; }
    }
}