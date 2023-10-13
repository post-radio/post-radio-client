using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Logs;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class MessagePipe<TRequest, TResponse> : IMessagePipe<TRequest, TResponse>,
        IMessageSender<TRequest, TResponse>
        where TRequest : IRagonEvent, IMessage, new()
        where TResponse : IRagonEvent, IMessage, new()
    {
        public MessagePipe(RagonEntity entity, MessengerLogger logger)
        {
            _entity = entity;
            _logger = logger;

            _requestListener = _entity.OnEvent<TRequest>(OnRequest);
            _responseListener = _entity.OnEvent<TResponse>(OnResponse);
        }

        private readonly RagonEntity _entity;
        private readonly MessengerLogger _logger;

        private readonly Action<RagonPlayer, IRagonEvent> _requestListener;
        private readonly Action<RagonPlayer, IRagonEvent> _responseListener;

        private readonly Dictionary<Guid, IRequestHandler<TRequest, TResponse>> _requestHandlers = new();

        private Func<IResponseHandler<TRequest, TResponse>, UniTask> _requestRoute;

        public void Dispose()
        {
            _entity.OffEvent<TRequest>(_requestListener);
            _entity.OffEvent<TResponse>(_responseListener);
        }

        public void AddRequestRoute(Func<IResponseHandler<TRequest, TResponse>, UniTask> route)
        {
            _requestRoute = route;
        }

        public IRequestHandler<TRequest, TResponse> SendRequest(RagonPlayer player, TRequest payload)
        {
            var id = Guid.NewGuid();
            payload.RequestId = id;

            var requestHandler = new RequestHandler<TRequest, TResponse>(id, player, payload);
            _requestHandlers.Add(id, requestHandler);
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);

            _logger.OnDirectRequestSent<TRequest>(player);

            return requestHandler;
        }

        public void SendResponse(RagonPlayer player, TResponse payload)
        {
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);
            _logger.OnDirectResponseSent<TResponse>(player);
        }

        private void OnRequest(RagonPlayer player, TRequest request)
        {
            var responseHandler = new ResponseHandler<TRequest, TResponse>(player, request, this);
            _requestRoute?.Invoke(responseHandler).Forget();
            _logger.OnDirectRequestReceived<TRequest>(player);
        }

        private void OnResponse(RagonPlayer player, TResponse response)
        {
            if (_requestHandlers.TryGetValue(response.RequestId, out var responseHandler) == false)
            {
                _logger.NoResponseHandlerFoundException<TResponse>(response.RequestId);
                throw new NullReferenceException();
            }

            responseHandler.OnResponded(response);
            _logger.OnDirectResponseReceived<TResponse>(player);
        }
    }
}