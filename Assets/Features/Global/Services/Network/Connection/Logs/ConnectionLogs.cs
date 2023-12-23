using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Network.Connection.Logs
{
    [Serializable]
    public class ConnectionLogs : ReadOnlyDictionary<ConnectionLogType, bool>
    {
    }
}