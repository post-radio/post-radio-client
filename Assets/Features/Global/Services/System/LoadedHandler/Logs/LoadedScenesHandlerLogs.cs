using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.System.LoadedHandler.Logs
{
    [Serializable]
    public class LoadedScenesHandlerLogs : ReadOnlyDictionary<LoadedScenesHandlerLogType, bool>
    {
    }
}