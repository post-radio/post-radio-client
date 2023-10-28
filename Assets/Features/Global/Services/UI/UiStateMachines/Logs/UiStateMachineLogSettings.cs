﻿using Global.UI.UiStateMachines.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.UiStateMachines.Logs
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [CreateAssetMenu(fileName = UiStateMachineRouter.LogsName,
        menuName = UiStateMachineRouter.LogsPath)]
    public class UiStateMachineLogSettings : LogSettings<UiStateMachineLogs, UiStateMachineLogType>
    {
        [SerializeField] [Indent] private LogParameters _logParameters;

        public LogParameters LogParameters => _logParameters;
    }
}