using GamePlay.Player.Entity.Components.Identity.Common;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Identity.Remote
{
    public class RemoteIdentity : RagonProperty, IPlayerIdentity
    {
        public RemoteIdentity() : base(0, false)
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