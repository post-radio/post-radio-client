using Global.Cameras.Persistent.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Persistent.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = GlobalCameraRoutes.LogsName,
        menuName = GlobalCameraRoutes.LogsPath)]
    public class GlobalCameraLogSettings : LogSettings<GlobalCameraLogs, GlobalCameraLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}