using Global.UI.Nova.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Nova.InputManagers.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = NovaRoutes.LogsName,
        menuName = NovaRoutes.LogsPath)]
    public class InputManagerLogSettings : LogSettings<InputManagerLogs, InputManagerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;
        public LogParameters LogParameters => _logParameters;
    }
}