using Global.System.LoadedHandler.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.LoadedHandler.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = LoadedScenesHandlerRoutes.LogsName,
        menuName = LoadedScenesHandlerRoutes.LogsPath)]
    public class LoadedScenesHandlerLogSettings : LogSettings<LoadedScenesHandlerLogs, LoadedScenesHandlerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}