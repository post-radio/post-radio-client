using GamePlay.Network.Common;
using GamePlay.Network.Common.Paths;

namespace GamePlay.Network.Messaging.REST.Common
{
    public class MessengerRoutes
    {
        public const string ServiceName = GamePlayNetworkAssetsPrefixes.Service + "Messeges";
        public const string ServicePath = GamePlayNetworkAssetsPaths.Root + "Messeges/Service";

        public const string LogsName = GamePlayNetworkAssetsPrefixes.Logs + "Messeges";
        public const string LogsPath = GamePlayNetworkAssetsPaths.Root + "Messeges/Logs";
    }
}