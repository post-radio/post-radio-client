using Global.Common;

namespace Global.System.MessageBrokers.Common
{
    public class MessageBrokerRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "System/MessageBroker/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "MessageBroker";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "MessageBroker";
    }
}