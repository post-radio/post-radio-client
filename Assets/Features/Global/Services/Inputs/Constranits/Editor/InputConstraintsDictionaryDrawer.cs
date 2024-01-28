using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Inputs.Constranits.Runtime;
using UnityEditor;

namespace Global.Inputs.Constranits.Editor
{
    [CustomPropertyDrawer(typeof(InputConstraintsDictionary))]
    public class InputConstraintsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}