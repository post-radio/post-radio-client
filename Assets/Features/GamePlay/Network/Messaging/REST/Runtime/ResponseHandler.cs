using System;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class ResponseHandler<TRequest, TResponse> : IResponseHandler<TRequest, TResponse>
        where TRequest : IRagonEvent, IMessage, new()
        where TResponse : IRagonEvent, IMessage, new()
    {
        public ResponseHandler(RagonPlayer player, TRequest requestPayload, IMessageSender<TRequest, TResponse> sender)
        {
            _requestId = requestPayload.RequestId.Value;
            _player = player;
            _requestPayload = requestPayload;
            _sender = sender;
        }

        private readonly Guid _requestId;
        private readonly RagonPlayer _player;
        private readonly TRequest _requestPayload;
        private readonly IMessageSender<TRequest, TResponse> _sender;

        public Guid RequestId => _requestId;
        public TRequest RequestPayload => _requestPayload;
        
        public void Response(TResponse payload)
        {
            payload.RequestId.SetValue(_requestId);
            _sender.SendResponse(_player, payload);
        }
    }
}