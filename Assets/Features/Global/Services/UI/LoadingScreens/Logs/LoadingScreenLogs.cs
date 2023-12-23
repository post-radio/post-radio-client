using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Global.UI.LoadingScreens.Logs
{
    [Serializable]
    public class LoadingScreenLogs : ReadOnlyDictionary<LoadingScreenLogType, bool>
    {
    }
}