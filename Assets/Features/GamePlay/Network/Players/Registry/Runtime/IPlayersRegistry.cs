using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public interface IPlayersRegistry
    {
        void Add(RagonPlayer player, RemotePlayerData data);
        RemotePlayerData Get(RagonPlayer player);
    }
}