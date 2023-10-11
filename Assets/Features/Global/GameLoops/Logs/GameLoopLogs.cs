using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.GameLoops.Logs
{
    [Serializable]
    public class GameLoopLogs : ReadOnlyDictionary<GameLoopLogType, bool>
    {
    }
}