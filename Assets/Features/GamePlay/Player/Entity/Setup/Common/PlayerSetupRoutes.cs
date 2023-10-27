using GamePlay.Player.Common.Paths;

namespace GamePlay.Player.Entity.Setup.Common
{
    public class PlayerSetupRoutes
    {
        public const string LocalPath = PlayerAssetsPaths.Root + "Setup/Local";
        public const string LocalName = PlayerAssetsPrefixes.Component + "Setup_Local";
        
        public const string RemotePath = PlayerAssetsPaths.Root + "Setup/Remote";
        public const string RemoteName = PlayerAssetsPrefixes.Component + "Setup_Remote";
    }
}