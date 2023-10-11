using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.System.ApplicationProxies.Logs
{
    [Serializable]
    public class ApplicationProxyLogs : ReadOnlyDictionary<ApplicationProxyLogType, bool>
    {
    }
}