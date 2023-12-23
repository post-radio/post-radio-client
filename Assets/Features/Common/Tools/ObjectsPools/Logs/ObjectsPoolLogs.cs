using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Common.Tools.ObjectsPools.Logs
{
    [Serializable]
    public class ObjectsPoolLogs : ReadOnlyDictionary<ObjectsPoolLogType, bool>
    {
    }
}