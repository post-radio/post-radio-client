using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Cameras.Persistent.Logs;
using UnityEditor;

namespace Global.Cameras.Persistent.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(GlobalCameraLogs))]
    public class GlobalCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}