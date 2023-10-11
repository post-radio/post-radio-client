using Internal.Services.Loggers.Runtime;
using Internal.Services.Scenes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Scenes.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ScenesFlowRoutes.LogsName,
        menuName = ScenesFlowRoutes.LogsPath)]
    public class ScenesFlowLogSettings : LogSettings<ScenesFlowLogs, ScenesFlowLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}