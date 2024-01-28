using Global.Cameras.Utils.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Utils.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.LogsName,
        menuName = CameraUtilsRoutes.LogsPath)]
    public class CameraUtilsLogSettings : LogSettings<CameraUtilsLogs, CameraUtilsLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}