using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Cameras.CurrentProvider.Logs;
using UnityEditor;

namespace Global.Cameras.CurrentProvider.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CurrentCameraLogs))]
    public class CurrentCameraLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}