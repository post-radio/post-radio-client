using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Network.Messaging.REST.Logs
{
    [Serializable]
    public class MessengerLogs : ReadOnlyDictionary<MessengerLogType, bool>
    {
    }
}