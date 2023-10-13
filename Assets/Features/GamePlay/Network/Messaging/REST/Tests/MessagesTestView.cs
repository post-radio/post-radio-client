using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Ragon.Client;
using UnityEngine;
using VContainer;

namespace GamePlay.Network.Messaging.REST.Tests
{
    public class MessagesTestView : MonoBehaviour, INetworkAwakeListener
    {
        [Inject]
        private void Construct(IMessenger messenger, IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
            _messenger = messenger;
        }

        [SerializeField] private MessagesTestClientView _client;

        private IMessenger _messenger;
        private IClientProvider _clientProvider;

        private void OnEnable()
        {
            _client.SendClicked += OnSendClicked;
        }

        private void OnDisable()
        {
            _client.SendClicked -= OnSendClicked;
        }

        public void OnNetworkAwake()
        {
            _client.SetName(_clientProvider.Client.Room.Local.Id);
            _messenger.AddRoute<TestRequest, TestResponse>(ProcessRequest);
        }

        private void OnSendClicked(int value)
        {
            ProcessSend(value).Forget();
        }

        private async UniTask ProcessSend(int value)
        {
            var player = GetAnotherPlayer();
            var payload = new TestRequest()
            {
                Value = value
            };

            var respond = await _messenger.RequestAsync<TestRequest, TestResponse>(
                player,
                payload,
                new CancellationTokenSource().Token);

            _client.SetValue(respond.Value);
        }
        
        private async UniTask ProcessRequest(IResponseHandler<TestRequest, TestResponse> responseHandler)
        {
            responseHandler.Response(new TestResponse() { Value = _client.Value });
        }

        private RagonPlayer GetAnotherPlayer()
        {
            var players = _clientProvider.Client.Room.Players;

            foreach (var player in players)
            {
                if (player.IsLocal == false)
                    return player;
            }

            throw new NullReferenceException();
        }
    }
}