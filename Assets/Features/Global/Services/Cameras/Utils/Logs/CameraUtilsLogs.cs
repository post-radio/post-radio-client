using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.Utils.Logs
{
    [Serializable]
    public class CameraUtilsLogs : ReadOnlyDictionary<CameraUtilsLogType, bool>
    {
    }
}