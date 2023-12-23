using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Network.Messaging.Events.Logs;
using UnityEditor;

namespace GamePlay.Network.Messaging.Events.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(NetworkEventsLogs))]
    public class NetworkEventsLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}