using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Inputs.View.Logs;
using UnityEditor;

namespace Global.Inputs.View.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(InputViewLogs))]
    public class InputViewLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}