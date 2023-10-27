using GamePlay.Player.Entity.Components.Identity.Common;
using GamePlay.Player.Entity.Components.Identity.Local;
using GamePlay.Player.Entity.Components.Location.Common;
using GamePlay.Player.Entity.Components.Location.Local;
using GamePlay.Player.Entity.Components.Root.Common;
using GamePlay.Player.Entity.Components.Visual.Common;
using GamePlay.Player.Entity.Components.Visual.Local;

namespace GamePlay.Player.Entity.Components.Root.Local
{
    public class LocalRoot : IPlayerRoot
    {
        public LocalRoot(LocalIdentity identity, LocalLocation location, LocalVisual visual)
        {
            _identity = identity;
            _location = location;
            _visual = visual;
        }
        
        private readonly LocalIdentity _identity;
        private readonly LocalLocation _location;
        private readonly LocalVisual _visual;

        public IPlayerIdentity Identity => _identity;
        public IPlayerLocation Location => _location;
        public IPlayerVisual Visual => _visual;
    }
}