using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    {
        public RequestHandler(Guid requestId, RagonPlayer requestOwner, TRequest requestPayload)
        {
            _requestId = requestId;
            _requestOwner = requestOwner;
            _requestPayload = requestPayload;

            _completionSources = new List<UniTaskCompletionSource<TResponse>>();
        }

        private readonly Guid _requestId;
        private readonly RagonPlayer _requestOwner;
        private readonly TRequest _requestPayload;

        private readonly List<UniTaskCompletionSource<TResponse>> _completionSources;

        private TResponse _responsePayload;

        public TRequest RequestPayload => _requestPayload;
        public TResponse ResponsePayload => _responsePayload;
        public RagonPlayer RequestOwner => _requestOwner;

        public event Action<TResponse> Responded;

        public Guid RequestId => _requestId;
        public bool ContainsResponse => _responsePayload != null;

        public void OnResponded(TResponse payload)
        {
            _responsePayload = payload;
            
            foreach (var completion in _completionSources)
                completion.TrySetResult(payload);
            
            Responded?.Invoke(payload);
        }

        public UniTaskCompletionSource<TResponse> CreateCompletionSource(CancellationToken cancellation)
        {
            var completion = new UniTaskCompletionSource<TResponse>();
            _completionSources.Add(completion);
            
            cancellation.Register(() =>
            {
                completion.TrySetCanceled();
                _completionSources.Remove(completion);
            });

            return completion;
        }
    }
}