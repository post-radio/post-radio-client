using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.System.ResourcesCleaners.Logs
{
    [Serializable]
    public class ResourcesCleanerLogs : ReadOnlyDictionary<ResourcesCleanerLogType, bool>
    {
    }
}