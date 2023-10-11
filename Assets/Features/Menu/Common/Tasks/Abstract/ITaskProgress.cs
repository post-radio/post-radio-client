namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskProgress
    {
        int Previous { get; }
        int Current { get; }
        int Target { get; }
        bool IsCompleted { get; }

        void Fetch();
        void OnProgress(int value);
    }
}