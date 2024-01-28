using GamePlay.Network.Common.Paths;

namespace GamePlay.Network.Room.Lifecycle.Common
{
    public class RoomStarterRoutes
    {
        public const string ServiceName = GamePlayNetworkAssetsPrefixes.Service + "RoomStarter";
        public const string ServicePath = GamePlayNetworkAssetsPaths.Root + "RoomStarter/Service";
        
        public const string MockName = GamePlayNetworkAssetsPrefixes.Service + "Mock_RoomStarter";
        public const string MockPath = GamePlayNetworkAssetsPaths.Root + "RoomStarter/Mock";
    }
}