using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.System.ResourcesCleaners.Logs
{
    [Serializable]
    public class ResourcesCleanerLogs : ReadOnlyDictionary<ResourcesCleanerLogType, bool>
    {
    }
}