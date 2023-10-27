using GamePlay.Player.Entity.Components.Visual.Common;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Visual.Local
{
    public class LocalVisual : RagonProperty, IPlayerVisual
    {
        protected LocalVisual() : base(0, false)
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