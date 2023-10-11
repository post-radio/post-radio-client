namespace Menu.Common.Tasks.Abstract
{
    public interface IGoalTask
    {
        ITaskData Data { get; }
        ITaskCompletionChecker CompletionChecker { get; }
        ITaskCompletionProcessor CompletionProcessor { get; }
        ITaskProgress Progress { get; }
    }
}