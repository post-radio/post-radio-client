using System;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessagePipe<TRequest, TResponse>
        where TRequest : IRagonEvent, new()
        where TResponse : IRagonEvent, new()
    {
        void Dispose();

        void AddRequestRoute(Func<IResponseHandler<TRequest, TResponse>, UniTask> route);
    }
}