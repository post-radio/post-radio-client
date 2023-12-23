using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Network.Messaging.Events.Logs
{
    [Serializable]
    public class NetworkEventsLogs : ReadOnlyDictionary<NetworkEventsLogType, bool>
    {
    }
}