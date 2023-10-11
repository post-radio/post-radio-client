namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskCompletionProcessor
    {
        void Construct(ITaskCompletionChecker completionChecker);
        void Enable();
        void Dispose();
    }
}