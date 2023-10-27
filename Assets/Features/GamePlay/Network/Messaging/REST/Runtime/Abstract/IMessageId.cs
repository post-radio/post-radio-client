using System;

namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessageId
    {
        Guid Value { get; }

        void SetValue(Guid value);
    }
}