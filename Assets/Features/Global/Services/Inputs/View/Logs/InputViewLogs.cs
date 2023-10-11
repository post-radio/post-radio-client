using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Global.Inputs.View.Logs
{
    [Serializable]
    public class InputViewLogs : ReadOnlyDictionary<InputViewLogType, bool>
    {
    }
}