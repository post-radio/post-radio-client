namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskTrigger<T>
    {
        IGoalTask CreateHandle();
    }
}