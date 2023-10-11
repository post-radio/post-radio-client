using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Services.LevelCameras.Logs
{
    [Serializable]
    public class LevelCameraLogs : ReadOnlyDictionary<LevelCameraLogType, bool>
    {
    }
}