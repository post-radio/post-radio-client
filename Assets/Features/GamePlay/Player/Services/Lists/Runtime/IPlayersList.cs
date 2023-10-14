using System.Collections.Generic;
using GamePlay.Player.Services.Entity;
using Ragon.Client;

namespace GamePlay.Player.Services.Lists.Runtime
{
    public interface IPlayersList
    {
        NetworkPlayer Owner { get; }
        IReadOnlyList<NetworkPlayer> All { get; }
        
        void Add(RagonPlayer player, NetworkPlayer data);
        NetworkPlayer Get(RagonPlayer player);
    }
}