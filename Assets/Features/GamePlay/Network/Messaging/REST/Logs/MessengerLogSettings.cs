using GamePlay.Network.Messaging.REST.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Messaging.REST.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = MessengerRoutes.LogsName,
        menuName = MessengerRoutes.LogsPath)]
    public class MessengerLogSettings : LogSettings<MessengerLogs, MessengerLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}