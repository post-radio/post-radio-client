using GamePlay.Player.Entity.Components.Identity.Common;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Identity.Local
{
    public class LocalIdentity : RagonProperty, IPlayerIdentity
    {
        public LocalIdentity() : base(0, false)
        {
        }

        public string DisplayName { get; }
        
        public override void Serialize(RagonBuffer buffer)
        {
        }

        public override void Deserialize(RagonBuffer buffer)
        {
        }
    }
}