using GamePlay.Player.Common.Paths;

namespace GamePlay.Player.Entity.Components.Identity.Common
{
    public class IdentityRoutes
    {
        public const string LocalComponentPath = PlayerAssetsPaths.Root + "Identity/Local";
        public const string LocalComponentName = PlayerAssetsPrefixes.Component + "Identity_Local";
        
        public const string RemoteComponentPath = PlayerAssetsPaths.Root + "Identity/Remote";
        public const string RemoteComponentName = PlayerAssetsPrefixes.Component + "Identity_Remote";
    }
}