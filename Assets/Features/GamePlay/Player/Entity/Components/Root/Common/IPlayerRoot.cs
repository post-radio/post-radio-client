using GamePlay.Player.Entity.Components.Identity.Common;
using GamePlay.Player.Entity.Components.Location.Common;
using GamePlay.Player.Entity.Components.Visual.Common;

namespace GamePlay.Player.Entity.Components.Root.Common
{
    public interface IPlayerRoot
    {
        IPlayerIdentity Identity { get; }
        IPlayerLocation Location { get; }
        IPlayerVisual Visual { get; }
    }
}