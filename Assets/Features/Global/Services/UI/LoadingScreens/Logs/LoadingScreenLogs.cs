using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.UI.LoadingScreens.Logs
{
    [Serializable]
    public class LoadingScreenLogs : ReadOnlyDictionary<LoadingScreenLogType, bool>
    {
    }
}