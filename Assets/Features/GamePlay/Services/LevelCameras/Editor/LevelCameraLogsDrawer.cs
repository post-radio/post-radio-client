using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Services.LevelCameras.Logs;
using UnityEditor;

namespace GamePlay.Services.LevelCameras.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LevelCameraLogs))]
    public class LevelCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}