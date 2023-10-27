using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Logs;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class Messenger : IMessenger, INetworkSceneEntityCreationListener
    {
        public Messenger(IClientProvider clientProvider, MessengerLogger logger)
        {
            _clientProvider = clientProvider;
            _logger = logger;
        }

        private readonly IClientProvider _clientProvider;
        private readonly MessengerLogger _logger;
        private readonly Dictionary<Type, object> _pipes = new();

        private RagonEntity _entity;

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _entity = await factory.Create();
        }

        public void AddRoute<TRequest, TResponse>(Func<IResponseHandler<TRequest, TResponse>, UniTask> route)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            _clientProvider.Client.Event.Register<TRequest>();
            _clientProvider.Client.Event.Register<TResponse>();
            
            var pipe = CreatePipe<TRequest, TResponse>();
            pipe.AddRequestRoute(route);
        }

        public IRequestHandler<TRequest, TResponse> Request<TRequest, TResponse>(
            RagonPlayer player,
            TRequest requestPayload)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var sender = GetSender<TRequest, TResponse>();
            var requestHandler = sender.SendRequest(player, requestPayload);

            return requestHandler;
        }

        public async UniTask<TResponse> RequestAsync<TRequest, TResponse>(
            RagonPlayer player, 
            TRequest requestPayload, 
            CancellationToken cancellation)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var requestHandler = Request<TRequest, TResponse>(player, requestPayload);

            var completion = requestHandler.CreateCompletionSource(cancellation);
            var responsePayload = await completion.Task;
            
            return responsePayload;
        }

        private IMessageSender<TRequest, TResponse> GetSender<TRequest, TResponse>()
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var type = typeof(TRequest);

            if (_pipes.TryGetValue(type, out var pipe) == false)
                pipe = CreatePipe<TRequest, TResponse>();

            if (pipe is not IMessageSender<TRequest, TResponse> sender)
                throw new NullReferenceException();

            return sender;
        }

        private IMessagePipe<TRequest, TResponse> CreatePipe<TRequest, TResponse>()
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var type = typeof(TRequest);

            var pipe = new MessagePipe<TRequest, TResponse>(_entity, _logger);
            _pipes.Add(type, pipe);
            
            _logger.OnPipeAdded<TRequest, TResponse>();

            return pipe;
        }
    }
}