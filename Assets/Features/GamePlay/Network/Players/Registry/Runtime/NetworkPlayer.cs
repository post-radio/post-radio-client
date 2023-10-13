using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class NetworkPlayer
    {
        public NetworkPlayer(RagonEntity entity)
        {
            Entity = entity;
        }
        
        public readonly RagonEntity Entity;
        public readonly RagonPlayer Player;
        public readonly string DisplayName;

        public string Id => Player.Id;
    }
}