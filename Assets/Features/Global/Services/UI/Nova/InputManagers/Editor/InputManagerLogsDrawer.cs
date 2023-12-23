using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.UI.Nova.InputManagers.Logs;
using UnityEditor;

namespace Global.UI.Nova.InputManagers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(InputManagerLogs))]
    public class InputManagerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}