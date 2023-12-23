using System.Collections.Generic;
using GamePlay.Player.Entity.Definition;
using Ragon.Client;

namespace GamePlay.Player.Services.Lists.Runtime
{
    public interface IPlayersList
    {
        INetworkPlayer Owner { get; }
        IReadOnlyList<INetworkPlayer> All { get; }
        
        void Add(INetworkPlayer data);
        INetworkPlayer Get(RagonPlayer player);
    }
}