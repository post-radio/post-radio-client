using System;

namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskCompletionChecker
    {
        event Action Completed;

        void Construct();
        void Dispose();
    }
}