using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.CurrentProvider.Logs
{
    [Serializable]
    public class CurrentCameraLogs : ReadOnlyDictionary<CurrentCameraLogType, bool>
    {
    }
}