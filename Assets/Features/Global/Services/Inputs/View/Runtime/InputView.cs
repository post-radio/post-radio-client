using System;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Global.Inputs.View.Runtime.Sources;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Runtime
{
    public class InputView :
        IInputView,
        IInputViewRebindCallbacks,
        IScopeAwakeListener
    {
        public InputView(
            IInputSourcesHandler inputSourcesHandler,
            IUpdater updater,
            InputActions inputActions,
            Controls controls,
            InputViewLogger logger)
        {
            _inputSourcesHandler = inputSourcesHandler;
            _updater = updater;
            _inputActions = inputActions;
            _controls = controls;
            _logger = logger;
        }

        private readonly InputViewLogger _logger;

        private readonly IInputSourcesHandler _inputSourcesHandler;
        private readonly IUpdater _updater;
        private readonly InputActions _inputActions;
        private readonly Controls _controls;
        
        public event Action DebugConsolePreformed;

        public void OnAwake()
        {
            _controls.Enable();
            _inputSourcesHandler.InvokeListen();
            _updater.Add(_inputActions);
        }

        public void OnBeforeRebind()
        {
            _inputSourcesHandler.Dispose();

            _logger.OnBeforeRebind();
        }

        public void OnAfterRebind()
        {
            _inputSourcesHandler.InvokeListen();

            _logger.OnAfterRebind();
        }

        private void OnDebugConsolePreformed(InputAction.CallbackContext context)
        {
            DebugConsolePreformed?.Invoke();
        }
    }
}