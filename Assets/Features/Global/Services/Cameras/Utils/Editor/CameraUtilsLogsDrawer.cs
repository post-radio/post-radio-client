using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Cameras.Utils.Logs;
using UnityEditor;

namespace Global.Cameras.Utils.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(CameraUtilsLogs))]
    public class CameraUtilsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}