using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.System.LoadedHandler.Logs;
using UnityEditor;

namespace Global.System.LoadedHandler.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LoadedScenesHandlerLogs))]
    public class LoadedScenesHandlerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}