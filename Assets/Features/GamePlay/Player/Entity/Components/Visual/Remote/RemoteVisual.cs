using GamePlay.Player.Entity.Components.Visual.Common;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Visual.Remote
{
    public class RemoteVisual : RagonProperty, IPlayerVisual
    {
        protected RemoteVisual() : base(0, false)
        {
        }
        
        public override void Serialize(RagonBuffer buffer)
        {
            
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            
        }
    }
}