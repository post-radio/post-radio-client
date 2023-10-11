using Common.Serialization.ReadOnlyDictionaries.Editor;
using Internal.Services.Scenes.Logs;
using UnityEditor;

namespace Internal.Services.Scenes.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ScenesFlowLogs))]
    public class ScenesFlowLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}