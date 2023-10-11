using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Common.Architecture.ObjectsPools.Logs
{
    [Serializable]
    public class ObjectsPoolLogs : ReadOnlyDictionary<ObjectsPoolLogType, bool>
    {
    }
}