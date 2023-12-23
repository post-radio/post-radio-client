using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.GameLoops.Logs
{
    [Serializable]
    public class GameLoopLogs : ReadOnlyDictionary<GameLoopLogType, bool>
    {
    }
}