using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Network.Session.Logs
{
    [Serializable]
    public class SessionLogs : ReadOnlyDictionary<SessionLogType, bool>
    {
    }
}