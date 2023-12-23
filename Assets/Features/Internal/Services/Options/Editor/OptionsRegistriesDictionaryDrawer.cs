using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Internal.Services.Options.Runtime;
using UnityEditor;

namespace Internal.Services.Options.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(OptionsRegistriesDictionary))]
    public class OptionsRegistriesDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}