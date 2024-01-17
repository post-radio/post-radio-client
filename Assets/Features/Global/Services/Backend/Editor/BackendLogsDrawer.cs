using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Backend.Logs;
using UnityEditor;

namespace Global.Backend.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(BackendLogs))]

    public class BackendLogsDrawer :
        ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}