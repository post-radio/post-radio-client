using Ragon.Client;

namespace GamePlay.Player.Services.Entity
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