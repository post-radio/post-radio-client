using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Internal.Services.Scenes.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}