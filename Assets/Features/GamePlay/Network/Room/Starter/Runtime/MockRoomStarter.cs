using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;

namespace GamePlay.Network.Room.Starter.Runtime
{
    public class MockRoomStarter : INetworkDestroyListener
    {
        public MockRoomStarter(IRoomProvider roomProvider, IClientProvider clientProvider)
        {
            _roomProvider = roomProvider;
            _clientProvider = clientProvider;
        }
        
        private readonly IRoomProvider _roomProvider;
        private readonly IClientProvider _clientProvider;

        public async UniTask OnNetworkDestroy()
        {
            var joinHandler = new JoinHandler(_roomProvider, _clientProvider);
            var joinTask = joinHandler.ProcessJoin();
            
            _roomProvider.SceneLoaded();

            await joinTask;
        }
    }
}