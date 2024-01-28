using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.Persistent.Logs
{
    [Serializable]
    public class GlobalCameraLogs : ReadOnlyDictionary<GlobalCameraLogType, bool>
    {
    }
}