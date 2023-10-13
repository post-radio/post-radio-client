using GamePlay.Network.Common;
using GamePlay.Network.Common.Paths;

namespace GamePlay.Network.Objects.Factories.Common
{
    public class NetworkObjectFactoryRoutes
    {
        public const string RegistryPath = GamePlayNetworkAssetsPaths.Root + "ObjectsFactoriesRegistry";
        public const string RegistryName = GamePlayNetworkAssetsPrefixes.Service + "ObjectsFactoriesRegistry";
        
        public const string DynamicFactoryPath = GamePlayNetworkAssetsPaths.Root + "DynamicFactory";
        public const string DynamicFactoryName = GamePlayNetworkAssetsPrefixes.Service + "DynamicFactory";
    }
}