using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.System.MessageBrokers.Logs
{
    [Serializable]
    public class MessageBrokerLogs : ReadOnlyDictionary<MessageBrokerLogType, bool>
    {
    }
}