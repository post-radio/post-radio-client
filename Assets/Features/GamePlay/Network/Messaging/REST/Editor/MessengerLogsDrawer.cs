using Common.Serialization.ReadOnlyDictionaries.Editor;
using GamePlay.Network.Messaging.REST.Logs;
using UnityEditor;

namespace GamePlay.Network.Messaging.REST.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(MessengerLogs))]
    public class MessengerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}