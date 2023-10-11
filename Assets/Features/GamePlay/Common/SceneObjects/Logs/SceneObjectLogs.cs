using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Common.SceneObjects.Logs
{
    [Serializable]
    public class SceneObjectLogs : ReadOnlyDictionary<SceneObjectLogType, bool>
    {
    }
}