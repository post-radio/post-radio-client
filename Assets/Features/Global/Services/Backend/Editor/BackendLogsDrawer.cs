using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Services.Backend.Logs;
using UnityEditor;

namespace Global.Services.Backend.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(BackendLogs))]

    public class BackendLogsDrawer :
        ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}