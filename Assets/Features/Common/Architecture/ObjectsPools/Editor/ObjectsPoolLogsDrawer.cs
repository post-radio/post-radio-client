using Common.Architecture.ObjectsPools.Logs;
using Common.Serialization.ReadOnlyDictionaries.Editor;
using UnityEditor;

namespace Common.Architecture.ObjectsPools.Editor
{
    [ReadOnlyDictionaryPriority]    
    [CustomPropertyDrawer(typeof(ObjectsPoolLogs))]
    public class ObjectsPoolLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}