using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Common.Tools.ObjectsPools.Logs;
using UnityEditor;

namespace Common.Tools.ObjectsPools.Editor
{
    [ReadOnlyDictionaryPriority]    
    [CustomPropertyDrawer(typeof(ObjectsPoolLogs))]
    public class ObjectsPoolLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}