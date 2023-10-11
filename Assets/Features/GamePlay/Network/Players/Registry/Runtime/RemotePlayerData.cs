using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class RemotePlayerData
    {
        public RemotePlayerData(RagonEntity entity)
        {
            Entity = entity;
        }
        
        public readonly RagonEntity Entity;
    }
}