using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Services.Backend.Logs
{
    [Serializable]
    public class BackendLogs : ReadOnlyDictionary<BackendLogType, bool>
    {
    }
}