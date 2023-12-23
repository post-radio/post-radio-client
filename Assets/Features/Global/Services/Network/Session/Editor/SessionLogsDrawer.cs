using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using Global.Network.Session.Logs;
using UnityEditor;

namespace Global.Network.Session.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(SessionLogs))]
    public class SessionLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}