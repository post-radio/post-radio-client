﻿using Global.Common;

namespace Global.UI.UiStateMachines.Common
{
    public static class UiStateMachineRouter
    {
        private const string Paths = GlobalAssetsPaths.Root + "UI/StateMachine/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = GlobalAssetsPrefixes.Service + "UiStateMachine";

        public const string LogsPath = Paths + "Logger";
        public const string LogsName = GlobalAssetsPrefixes.Logs + "UiStateMachine";

        public const string ConstraintsPrefix = "UiConstraints_";
        public const string ConstraintsPath = Paths + "Constraints";
    }
}