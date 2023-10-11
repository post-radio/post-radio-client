using Common.Serialization.ReadOnlyDictionaries.Editor;
using Global.System.MessageBrokers.Logs;
using UnityEditor;

namespace Global.System.MessageBrokers.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(MessageBrokerLogs))]
    public class MessageBrokerLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}