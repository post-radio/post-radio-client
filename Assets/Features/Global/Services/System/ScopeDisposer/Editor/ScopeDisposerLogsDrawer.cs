using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.System.ScopeDisposer.Logs;
using UnityEditor;

namespace Global.System.ScopeDisposer.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScopeDisposerLogs))]
    public class ScopeDisposerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}