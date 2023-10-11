using System;

namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskTriggerListenerFactory<T>
    {
        IDisposable Create(Action<T> callback);
    }
}