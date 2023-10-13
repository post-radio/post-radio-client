using System.Collections.Generic;
using Ragon.Client;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public interface IPlayersList
    {
        NetworkPlayer Owner { get; }
        IReadOnlyList<NetworkPlayer> All { get; }
        
        void Add(RagonPlayer player, NetworkPlayer data);
        NetworkPlayer Get(RagonPlayer player);
    }
}