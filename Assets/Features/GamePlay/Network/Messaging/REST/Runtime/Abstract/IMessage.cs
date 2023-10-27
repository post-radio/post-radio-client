namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessage
    {
        IMessageId RequestId { get; }
    }
}