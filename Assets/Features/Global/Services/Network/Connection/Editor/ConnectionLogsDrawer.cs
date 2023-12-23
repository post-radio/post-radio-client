using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Network.Connection.Logs;
using UnityEditor;

namespace Global.Network.Connection.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ConnectionLogs))]
    public class ConnectionLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}