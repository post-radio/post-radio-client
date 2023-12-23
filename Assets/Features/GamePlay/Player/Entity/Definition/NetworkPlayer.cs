using GamePlay.Player.Entity.Components.Root.Common;
using Ragon.Client;

namespace GamePlay.Player.Entity.Definition
{
    public class NetworkPlayer : INetworkPlayer
    {
        public NetworkPlayer(RagonEntity entity, IPlayerRoot root)
        {
            _entity = entity;
            _root = root;
        }
     
        private readonly RagonEntity _entity;
        private readonly IPlayerRoot _root;
        
        public string Id => Player.Id;
        public RagonEntity Entity => _entity;
        public RagonPlayer Player => _entity.Owner;
        public IPlayerRoot Root => _root;
        public string DisplayName => _root.Identity.DisplayName;
    }
}