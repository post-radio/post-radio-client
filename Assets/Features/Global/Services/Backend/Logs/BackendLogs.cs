using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Backend.Logs
{
    [Serializable]
    public class BackendLogs : ReadOnlyDictionary<BackendLogType, bool>
    {
    }
}