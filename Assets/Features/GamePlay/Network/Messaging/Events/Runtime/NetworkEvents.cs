using System;
using System.Collections.Generic;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.Events.Logs;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Network.Messaging.Events.Runtime
{
    public class NetworkEvents : INetworkEvents, IScopeDisableListener, INetworkSceneEntityCreationListener
    {
        public NetworkEvents(IClientProvider clientProvider, NetworkEventsLogger logger)
        {
            _clientProvider = clientProvider;
            _logger = logger;
        }

        private readonly IClientProvider _clientProvider;
        private readonly NetworkEventsLogger _logger;
        private readonly CancellationTokenSource _cancellation = new();

        private readonly List<IDisposable> _listeners = new();

        private RagonEntity _entity;

        public void OnDisabled()
        {
            _cancellation.Cancel();

            foreach (var listener in _listeners)
                listener.Dispose();
        }

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _entity = await factory.Create();
        }

        public void AddRoute<TEvent>(Action<RagonPlayer, TEvent> listener) where TEvent : IRagonEvent, new()
        {
            _clientProvider.Client.Event.Register<TEvent>();
            
            var disposable = _entity.OnEvent(listener);
            _listeners.Add(disposable);

            _logger.OnRouteAdded<TEvent>();
        }

        public void AddRouteAsync<TEvent>(Func<RagonPlayer, TEvent, CancellationToken, UniTask> listener)
            where TEvent : IRagonEvent, new()
        {
            _clientProvider.Client.Event.Register<TEvent>();
            var receiver = new EventReceiver<TEvent>(_cancellation.Token, listener);
            var disposable = _entity.OnEvent<TEvent>(receiver.Listener);
            _listeners.Add(disposable);

            _logger.OnRouteAdded<TEvent>();
        }

        public void SendEvent<TEvent>(TEvent payload) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(payload, RagonTarget.All, RagonReplicationMode.LocalAndServer);

            _logger.OnEventSent<TEvent>();
        }

        public void SendEvent<TEvent>(TEvent payload, RagonPlayer player) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(payload, player, RagonReplicationMode.Server);

            _logger.OnEventSent<TEvent>();
        }
    }
}