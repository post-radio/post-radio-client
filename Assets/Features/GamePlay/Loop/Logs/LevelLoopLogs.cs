using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Loop.Logs
{
    [Serializable]
    public class LevelLoopLogs : ReadOnlyDictionary<LevelLoopLogType, bool>
    {
    }
}