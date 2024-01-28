using Global.Inputs.View.Common;
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Global.Inputs.View.Logs
{
    [CreateAssetMenu(fileName = InputViewRoutes.LogsName,
        menuName = InputViewRoutes.LogsPath)]
    public class InputViewLogSettings : LogSettings<InputViewLogs, InputViewLogType>
    {
        [SerializeField] private LogParameters _parameters;

        public LogParameters LogParameters => _parameters;
    }
}