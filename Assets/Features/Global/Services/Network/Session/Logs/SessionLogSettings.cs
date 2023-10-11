using Global.Network.Session.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Global.Network.Session.Logs
{
    [CreateAssetMenu(fileName = SessionRoutes.LogsName, menuName = SessionRoutes.LogsPath)]
    public class SessionLogSettings : LogSettings<SessionLogs, SessionLogType>
    {
        [SerializeField] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}