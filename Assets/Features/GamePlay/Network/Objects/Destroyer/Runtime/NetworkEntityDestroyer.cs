using Features.GamePlay.Network.Room.Lifecycle.Runtime;
using GamePlay.Network.Objects.Definition;

namespace GamePlay.Network.Objects.Destroyer.Runtime
{
    public class NetworkEntityDestroyer : INetworkEntityDestroyer
    {
        public NetworkEntityDestroyer(IRoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
        }
        
        private readonly IRoomProvider _roomProvider;
        
        public void Destroy(INetworkObject networkObject)
        {
            _roomProvider.Room.DestroyEntity(networkObject.Entity);
        }
    }
}