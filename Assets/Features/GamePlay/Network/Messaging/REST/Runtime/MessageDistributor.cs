using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using GamePlay.Network.Players.Registry.Runtime;
using Ragon.Client;

namespace GamePlay.Network.Messaging.REST.Runtime
{
    public class MessageDistributor : IMessageDistributor
    {
        public MessageDistributor(IMessenger messenger, IPlayersList players)
        {
            _messenger = messenger;
            _players = players;
        }

        private readonly IMessenger _messenger;
        private readonly IPlayersList _players;

        public IRequestHandler<TRequest, TResponse> SendOwner<TRequest, TResponse>(
            TRequest requestPayload)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            return _messenger.Request<TRequest, TResponse>(_players.Owner.Player, requestPayload);
        }

        public UniTask<TResponse> SendOwnerAsync<TRequest, TResponse>(
            TRequest requestPayload,
            CancellationToken cancellation)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            return _messenger.RequestAsync<TRequest, TResponse>(_players.Owner.Player, requestPayload, cancellation);
        }

        public IReadOnlyDictionary<NetworkPlayer, IRequestHandler<TRequest, TResponse>> SendAll<TRequest, TResponse>(
            TRequest requestPayload)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var list = new Dictionary<NetworkPlayer, IRequestHandler<TRequest, TResponse>>();

            foreach (var targetPlayer in _players.All)
            {
                var handler = _messenger.Request<TRequest, TResponse>(targetPlayer.Player, requestPayload);
                list.Add(targetPlayer, handler);
            }

            return list;
        }

        public async UniTask<IReadOnlyDictionary<NetworkPlayer, TResponse>> SendAllAsync<TRequest, TResponse>(
            TRequest requestPayload,
            CancellationToken cancellation)
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            var list = new List<UniTask<(NetworkPlayer, TResponse)>>();
            var dictionary = new Dictionary<NetworkPlayer, TResponse>();
            
            foreach (var targetPlayer in _players.All)
            {
                var handler = new AsyncMessageHandler<TRequest, TResponse>(
                    targetPlayer,
                    _messenger,
                    requestPayload,
                    cancellation);

                var tasks = handler.SendAsync();

                list.Add(tasks);
            }

            var result = await UniTask.WhenAll(list);
            
            foreach (var (player, response) in result)
                dictionary.Add(player, response);

            return dictionary;
        }

        public readonly struct AsyncMessageHandler<TRequest, TResponse>
            where TRequest : IRagonEvent, IMessage, new()
            where TResponse : IRagonEvent, IMessage, new()
        {
            private readonly NetworkPlayer _player;
            private readonly IMessenger _messenger;
            private readonly TRequest _requestPayload;
            private readonly CancellationToken _cancellation;

            public AsyncMessageHandler(
                NetworkPlayer player,
                IMessenger messenger,
                TRequest requestPayload,
                CancellationToken cancellation)
            {
                _player = player;
                _messenger = messenger;
                _requestPayload = requestPayload;
                _cancellation = cancellation;
            }

            public async UniTask<(NetworkPlayer, TResponse)> SendAsync()
            {
                var response = await _messenger.RequestAsync<TRequest, TResponse>(
                    _player.Player,
                    _requestPayload,
                    _cancellation);

                return (_player, response);
            }
        }
    }
}