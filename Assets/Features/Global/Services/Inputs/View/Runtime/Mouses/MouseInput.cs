using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Cameras.CameraUtilities.Runtime;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Listeners;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Runtime.Mouses
{
    public class MouseInput : IInputListener, IUpdatable, IMouseInput
    {
        public MouseInput(
            IInputConstraintsStorage constraintsStorage,
            IInputListenersHandler inputListenersHandler,
            IUpdater updater,
            ICameraUtils cameraUtils,
            Controls.GamePlayActions gamePlay,
            InputViewLogger logger)
        {
            _constraintsStorage = constraintsStorage;
            _updater = updater;
            _cameraUtils = cameraUtils;
            _gamePlay = gamePlay;
            _logger = logger;

            inputListenersHandler.AddListener(this);
        }

        private readonly IInputConstraintsStorage _constraintsStorage;
        private readonly IUpdater _updater;
        private readonly ICameraUtils _cameraUtils;
        private readonly Controls.GamePlayActions _gamePlay;
        private readonly InputViewLogger _logger;

        public event Action LeftDown;
        public event Action LeftUp;
        public event Action RightDown;
        public event Action RightUp;

        public Vector2 Position { get; private set; }

        public async UniTask WaitLeftDownAsync(CancellationToken cancellation)
        {
            var completion = new UniTaskCompletionSource();

            cancellation.Register(() =>
            {
                completion.TrySetCanceled();
                LeftDown -= OnDown;
            });

            LeftDown += OnDown;

            void OnDown()
            {
                completion.TrySetResult();
                LeftDown -= OnDown;
            }

            await completion.Task;
        }

        public Vector2 GetWorldPoint()
        {
            return _cameraUtils.ScreenToWorld(Position);
        }

        public void Listen()
        {
            _gamePlay.LeftClick.performed += OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled += OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed += OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled += OnRightMouseButtonUp;

            _updater.Add(this);
        }

        public void UnListen()
        {
            _gamePlay.LeftClick.performed -= OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled -= OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed -= OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled -= OnRightMouseButtonUp;

            _updater.Remove(this);
        }

        private void OnLeftMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnLeftMouseButtonDown();

            LeftDown?.Invoke();
        }

        private void OnLeftMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnLeftMouseButtonUp();

            LeftUp?.Invoke();
        }

        private void OnRightMouseButtonDown(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnRightMouseButtonDown();

            RightDown?.Invoke();
        }

        private void OnRightMouseButtonUp(InputAction.CallbackContext context)
        {
            if (_constraintsStorage[InputConstraints.Mouse] == true)
            {
                _logger.OnInputCanceledWithConstraint(InputConstraints.Mouse);
                return;
            }

            _logger.OnRightMouseButtonUp();

            RightUp?.Invoke();
        }

        public void OnUpdate(float delta)
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;

                if (touches.Length < 1)
                    return;

                Position = touches[0].rawPosition;
                LeftDown?.Invoke();

                _logger.OnLeftMouseButtonDown();
            }
            else
            {
                Position = Mouse.current.position.ReadValue();
            }
        }
    }
}