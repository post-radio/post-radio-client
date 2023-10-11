using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Cameras.GlobalCameras.Logs
{
    [Serializable]
    public class GlobalCameraLogs : ReadOnlyDictionary<GlobalCameraLogType, bool>
    {
    }
}