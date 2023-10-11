using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.System.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}