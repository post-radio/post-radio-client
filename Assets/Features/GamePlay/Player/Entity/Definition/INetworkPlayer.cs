using GamePlay.Player.Entity.Components.Root.Common;
using Ragon.Client;

namespace GamePlay.Player.Entity.Definition
{
    public interface INetworkPlayer
    {
        RagonEntity Entity { get; }
        RagonPlayer Player { get; }
        IPlayerRoot Root { get; }
    }
}