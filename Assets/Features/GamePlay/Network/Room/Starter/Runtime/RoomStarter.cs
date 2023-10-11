using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;

namespace GamePlay.Network.Room.Starter.Runtime
{   
    public class RoomStarter : INetworkStartListener
    {
        public RoomStarter(IRoomProvider roomProvider, ISceneEntityFactory sceneEntityFactory)
        {
            _roomProvider = roomProvider;
            _sceneEntityFactory = sceneEntityFactory;
        }
        
        private readonly IRoomProvider _roomProvider;
        private readonly ISceneEntityFactory _sceneEntityFactory;

        public async UniTask OnNetworkStart()
        {
            var flagEntityTask = _sceneEntityFactory.Create();
            _roomProvider.SceneLoaded();

            await flagEntityTask;
        }
    }
}