using Global.Network.Connection.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Global.Network.Connection.Logs
{
    [CreateAssetMenu(fileName = ConnectionRoutes.LogsName,
        menuName = ConnectionRoutes.LogsPath)]
    public class ConnectionLogSettings : LogSettings<ConnectionLogs, ConnectionLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}