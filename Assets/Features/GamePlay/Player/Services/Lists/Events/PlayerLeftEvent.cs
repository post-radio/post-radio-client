using GamePlay.Player.Entity.Definition;

namespace GamePlay.Player.Services.Lists.Events
{
    public readonly struct PlayerLeftEvent
    {
        public PlayerLeftEvent(INetworkPlayer player)
        {
            Player = player;
        }
        
        public readonly INetworkPlayer Player;
    }
}