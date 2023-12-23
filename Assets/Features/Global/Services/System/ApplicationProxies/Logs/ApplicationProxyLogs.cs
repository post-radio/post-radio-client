using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.System.ApplicationProxies.Logs
{
    [Serializable]
    public class ApplicationProxyLogs : ReadOnlyDictionary<ApplicationProxyLogType, bool>
    {
    }
}