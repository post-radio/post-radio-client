using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Network.Connection.Logs
{
    [Serializable]
    public class ConnectionLogs : ReadOnlyDictionary<ConnectionLogType, bool>
    {
    }
}