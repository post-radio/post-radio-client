using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.System.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}