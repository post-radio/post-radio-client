using GamePlay.Player.Common.Paths;

namespace GamePlay.Player.Entity.Components.Root.Common
{
    public class RootRoutes
    {
        public const string LocalComponentPath = PlayerAssetsPaths.Root + "Root/Local";
        public const string LocalComponentName = PlayerAssetsPrefixes.Component + "Root_Local";
        
        public const string RemoteComponentPath = PlayerAssetsPaths.Root + "Root/Remote";
        public const string RemoteComponentName = PlayerAssetsPrefixes.Component + "Root_Remote";
    }
}