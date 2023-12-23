using System;
using Global.System.MessageBrokers.Runtime;

namespace Menu.Common.Tasks.Abstract
{
    public class TaskTriggerListenerFactory<T> : ITaskTriggerListenerFactory<T>
    {
        public IDisposable Create(Action<T> callback)
        {
            return Msg.Listen(callback);
        }
    }
}