using GamePlay.Player.Entity.Components.Identity.Common;
using GamePlay.Player.Entity.Components.Identity.Remote;
using GamePlay.Player.Entity.Components.Location.Common;
using GamePlay.Player.Entity.Components.Location.Remote;
using GamePlay.Player.Entity.Components.Root.Common;
using GamePlay.Player.Entity.Components.Visual.Common;
using GamePlay.Player.Entity.Components.Visual.Remote;

namespace GamePlay.Player.Entity.Components.Root.Remote
{
    public class RemoteRoot : IPlayerRoot
    {
        public RemoteRoot(RemoteIdentity identity, RemoteLocation location, RemoteVisual visual)
        {
            _identity = identity;
            _location = location;
            _visual = visual;
        }
        
        private readonly RemoteIdentity _identity;
        private readonly RemoteLocation _location;
        private readonly RemoteVisual _visual;

        public IPlayerIdentity Identity => _identity;
        public IPlayerLocation Location => _location;
        public IPlayerVisual Visual => _visual;
    }
}