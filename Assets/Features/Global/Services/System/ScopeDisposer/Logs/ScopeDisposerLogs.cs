using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.System.ScopeDisposer.Logs
{
    [Serializable]
    public class ScopeDisposerLogs : ReadOnlyDictionary<ScopeDisposerLogType, bool>
    {
    }
}