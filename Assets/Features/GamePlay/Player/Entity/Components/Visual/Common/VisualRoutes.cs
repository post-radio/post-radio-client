using GamePlay.Player.Common.Paths;

namespace GamePlay.Player.Entity.Components.Visual.Common
{
    public class VisualRoutes
    {
        public const string LocalComponentPath = PlayerAssetsPaths.Root + "Visual/Local";
        public const string LocalComponentName = PlayerAssetsPrefixes.Component + "Visual_Local";
        
        public const string RemoteComponentPath = PlayerAssetsPaths.Root + "Visual/Remote";
        public const string RemoteComponentName = PlayerAssetsPrefixes.Component + "Visual_Remote";
    }
}