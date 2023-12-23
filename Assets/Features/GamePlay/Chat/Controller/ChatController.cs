using System;
using Cysharp.Threading.Tasks;
using GamePlay.Chat.Events;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using GamePlay.Player.Services.Lists.Runtime;
using Global.System.MessageBrokers.Runtime;
using Ragon.Client;

namespace GamePlay.Chat.Controller
{
    public class ChatController :
        IChatController,
        INetworkSceneEntityCreationListener,
        INetworkAwakeListener,
        INetworkDestroyListener
    {
        public ChatController(IPlayersList players)
        {
            _players = players;
        }

        private readonly IPlayersList _players;

        private RagonEntity _entity;
        
        private IDisposable _submitListener;
        private IDisposable _receiveListener;

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            _entity = await factory.Create();
        }

        public void OnNetworkAwake()
        {
            _submitListener = Msg.Listen<ChatMessageSubmittedEvent>(OnMessageSubmitted);
            _receiveListener = _entity.OnEvent<ChatMessageNetworkEvent>(OnMessageReceived);
        }

        public async UniTask OnNetworkDestroy()
        {
            _submitListener.Dispose();
            _receiveListener.Dispose();
        }
        
        private void OnMessageSubmitted(ChatMessageSubmittedEvent message)
        {
            var payload = new ChatMessageNetworkEvent { Message = message.Message };
            _entity.ReplicateEvent(payload);
        }
        
        private void OnMessageReceived(RagonPlayer player, ChatMessageNetworkEvent payload)
        {
            var networkPlayer = _players.Get(player);

            if (networkPlayer == null)
                return;

            Msg.Publish(new ChatMessageReceivedEvent(networkPlayer, payload.Message));
        }
    }
}