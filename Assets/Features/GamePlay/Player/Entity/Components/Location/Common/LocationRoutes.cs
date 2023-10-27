using GamePlay.Player.Common.Paths;

namespace GamePlay.Player.Entity.Components.Location.Common
{
    public class LocationRoutes
    {
        public const string LocalComponentPath = PlayerAssetsPaths.Root + "Location/Local";
        public const string LocalComponentName = PlayerAssetsPrefixes.Component + "Location_Local";
        
        public const string RemoteComponentPath = PlayerAssetsPaths.Root + "Location/Remote";
        public const string RemoteComponentName = PlayerAssetsPrefixes.Component + "Location_Remote";
    }
}