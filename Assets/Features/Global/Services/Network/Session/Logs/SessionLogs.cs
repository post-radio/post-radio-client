using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Network.Session.Logs
{
    [Serializable]
    public class SessionLogs : ReadOnlyDictionary<SessionLogType, bool>
    {
    }
}