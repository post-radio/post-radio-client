using System;

namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessage
    {
        Guid RequestId { get; set; }
    }
}