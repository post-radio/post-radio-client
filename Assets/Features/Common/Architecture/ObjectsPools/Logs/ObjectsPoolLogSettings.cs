using Common.Architecture.ObjectsPools.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Common.Architecture.ObjectsPools.Logs
{
    [CreateAssetMenu(fileName = ObjectsPoolRoutes.LogsName,
        menuName = ObjectsPoolRoutes.LogsPath)]
    public class ObjectsPoolLogSettings : LogSettings<ObjectsPoolLogs, ObjectsPoolLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}