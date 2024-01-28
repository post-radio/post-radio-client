using System;
using System.Threading;
using Common.DataTypes.Structs;
using Cysharp.Threading.Tasks;
using Global.Cameras.Utils.Runtime;
using Global.Inputs.Constranits.Definition;
using Global.Inputs.Constranits.Runtime;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Sources;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Implementations.Mouses
{
    public class MouseInput : IInputSource, IUpdatable, IMouseInput
    {
        public MouseInput(
            IInputConstraintsStorage constraintsStorage,
            IInputSourcesHandler inputListenersHandler,
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

        private bool _isWheelPressed;

        public event Action LeftDown;
        public event Action LeftUp;
        public event Action RightDown;
        public event Action RightUp;
        public event Action<Vertical> Scroll;

        public Vector2 Position { get; private set; }
        public bool IsWheelPressed => _isWheelPressed;

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
            
            _gamePlay.MouseWheel.performed += OnMouseWheelDown;
            _gamePlay.MouseWheel.canceled += OnMouseWheelUp;

            _gamePlay.Scroll.performed += OnScroll;

            _updater.Add(this);
        }

        public void UnListen()
        {
            _gamePlay.LeftClick.performed -= OnLeftMouseButtonDown;
            _gamePlay.LeftClick.canceled -= OnLeftMouseButtonUp;
            _gamePlay.RightClick.performed -= OnRightMouseButtonDown;
            _gamePlay.RightClick.canceled -= OnRightMouseButtonUp;
            
            _gamePlay.MouseWheel.performed += OnMouseWheelDown;
            _gamePlay.MouseWheel.canceled += OnMouseWheelUp;

            _gamePlay.Scroll.performed += OnScroll;

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
        
        
        private void OnScroll(InputAction.CallbackContext context)
        {
            var scroll = context.ReadValue<float>();
            
            if (scroll > 0f)
                Scroll?.Invoke(Vertical.Up);
            else
                Scroll?.Invoke(Vertical.Down);
        }

        private void OnMouseWheelDown(InputAction.CallbackContext context)
        {
            _isWheelPressed = true;

        }
        
        private void OnMouseWheelUp(InputAction.CallbackContext context)
        {
            _isWheelPressed = false;
        }

        public void OnUpdate(float delta)
        {
            if (Application.isMobilePlatform == true)
            {
                var touches = Input.touches;
                _isWheelPressed = false;
                
                if (touches.Length < 1)
                    return;

                Position = touches[0].rawPosition;
                _isWheelPressed = true;
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