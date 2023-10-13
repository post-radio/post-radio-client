using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime.Abstract
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TRequest RequestPayload { get; }
        TResponse ResponsePayload { get; }
        RagonPlayer RequestOwner { get; }
        bool ContainsResponse { get; }

        event Action<TResponse> Responded; 

        void OnResponded(TResponse payload);
        UniTaskCompletionSource<TResponse> CreateCompletionSource(CancellationToken cancellation);
    }
}