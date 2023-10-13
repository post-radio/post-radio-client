namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IResponseHandler<TRequest, TResponse>
    {
        TRequest RequestPayload { get; }

        void Response(TResponse payload);
    }
}