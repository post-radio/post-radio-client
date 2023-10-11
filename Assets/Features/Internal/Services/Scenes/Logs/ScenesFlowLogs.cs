using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Internal.Services.Scenes.Logs
{
    [Serializable]
    public class ScenesFlowLogs : ReadOnlyDictionary<ScenesFlowLogType, bool>
    {
    }
}