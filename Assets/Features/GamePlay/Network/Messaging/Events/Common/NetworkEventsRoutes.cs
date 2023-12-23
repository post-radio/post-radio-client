using GamePlay.Network.Common.Paths;

namespace GamePlay.Network.Messaging.Events.Common
{
    public class NetworkEventsRoutes
    {
        public const string ServiceName = GamePlayNetworkAssetsPrefixes.Service + "Events";
        public const string ServicePath = GamePlayNetworkAssetsPaths.Root + "Events/Service";

        public const string LogsName = GamePlayNetworkAssetsPrefixes.Logs + "Events";
        public const string LogsPath = GamePlayNetworkAssetsPaths.Root + "Events/Logs";   
    }
}