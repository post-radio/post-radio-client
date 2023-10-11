namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskFactory
    {
        string Key { get; }
        IGoalTask Create(int currentProgress);
    }
}