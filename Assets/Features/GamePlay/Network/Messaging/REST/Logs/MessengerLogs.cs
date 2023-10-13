using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Network.Messaging.REST.Logs
{
    [Serializable]
    public class MessengerLogs : ReadOnlyDictionary<MessengerLogType, bool>
    {
    }
}