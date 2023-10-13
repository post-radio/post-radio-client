using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IMessenger
    {
        void AddRoute<TRequest, TResponse>(Func<IResponseHandler<TRequest, TResponse>, UniTask> route)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new();

        IRequestHandler<TRequest, TResponse> Request<TRequest, TResponse>(RagonPlayer player, TRequest requestPayload)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new();
        
        UniTask<TResponse> RequestAsync<TRequest, TResponse>(
            RagonPlayer player, 
            TRequest requestPayload, 
            CancellationToken cancellation)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new();
    }
}