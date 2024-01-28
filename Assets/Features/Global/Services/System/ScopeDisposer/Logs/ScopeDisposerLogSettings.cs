using Global.System.ScopeDisposer.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ScopeDisposer.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = ScopeDisposerRoutes.LogsName,
        menuName = ScopeDisposerRoutes.LogsPath)]
    public class ScopeDisposerLogSettings : LogSettings<ScopeDisposerLogs, ScopeDisposerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}