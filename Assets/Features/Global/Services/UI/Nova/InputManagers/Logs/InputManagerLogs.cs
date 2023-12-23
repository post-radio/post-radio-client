using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.UI.Nova.InputManagers.Logs
{
    [Serializable]
    public class InputManagerLogs : ReadOnlyDictionary<InputManagerLogType, bool>
    {
    }
}