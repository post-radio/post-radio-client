using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace GamePlay.Common.SceneObjects.Logs
{
    [Serializable]
    public class SceneObjectLogs : ReadOnlyDictionary<SceneObjectLogType, bool>
    {
    }
}