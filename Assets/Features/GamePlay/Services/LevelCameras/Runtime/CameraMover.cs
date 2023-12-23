using Common.DataTypes.Structs;
using Global.Inputs.View.Runtime.Mouses;
using Global.System.ApplicationProxies.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Global.UI.Nova.InputManagers.Abstract;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class CameraMover : ICameraMover, IUpdatable
    {
        public CameraMover(
            ILevelCamera camera,
            IMouseInput input,
            IUpdater updater,
            IScreen screen,
            ICameraBorders borders,
            ICameraBlockListener blockListener,
            IUIInputManager uiInputManager,
            CameraMoverConfig config)
        {
            _camera = camera;
            _input = input;
            _updater = updater;
            _screen = screen;
            _borders = borders;
            _blockListener = blockListener;
            _uiInputManager = uiInputManager;
            _config = config;
        }

        private readonly ILevelCamera _camera;
        private readonly IMouseInput _input;
        private readonly IUpdater _updater;
        private readonly IScreen _screen;
        private readonly ICameraBorders _borders;
        private readonly ICameraBlockListener _blockListener;
        private readonly IUIInputManager _uiInputManager;
        private readonly CameraMoverConfig _config;

        private Vector2 _previousPosition;

        public void Enable()
        {
            _input.Scroll += OnScroll;
            _updater.Add(this);
            
            var offset = _borders.GetBordersOffset(_camera.Position, _camera.Scale, _camera.Aspect);
            _camera.SetPosition(_camera.Position + offset);
        }

        public void Disable()
        {
            _input.Scroll -= OnScroll;
            _updater.Remove(this);
        }

        private void OnScroll(Vertical direction)
        {
            if (_uiInputManager.IsCollidingLayer(LayerMask.GetMask("UI")) == true)
                return;
            
            var scale = _camera.Scale;
            var delta = _config.ZoomSensitivity;

            if (direction == Vertical.Up)
                delta *= -1;

            scale += delta;
            scale = Mathf.Clamp(scale, _config.MinZoom, _config.MaxZoom);
            _camera.SetScale(scale);
        }

        public void OnUpdate(float delta)
        {
            if (_blockListener.IsBlocked == true)
                return;
            
            var scrollProgression = _camera.Scale / _config.MaxZoom;
            
            if (_input.IsWheelPressed == true)
            {
                var direction = _input.Position - _previousPosition;
                direction = direction.normalized * (-1f * scrollProgression);
                MoveCamera(direction);

                _previousPosition = _input.Position;
            }

            var offset = _borders.GetBordersOffset(_camera.Position, _camera.Scale, _camera.Aspect);
            _camera.SetPosition(_camera.Position + offset);
        }

        private void MoveCamera(Vector2 direction)
        {
            var move = direction * _config.MoveSensitivity;
            var position = _camera.Position + move;
            _camera.SetPosition(position);
        }

        private bool IsInBorder(Vector2 position)
        {
            var resolution = _screen.Resolution;

            if (position.y < _config.ScreenBordersWidth)
                return true;

            if (position.y > resolution.y - _config.ScreenBordersWidth)
                return true;

            if (position.x < _config.ScreenBordersWidth)
                return true;

            if (position.x > resolution.x - _config.ScreenBordersWidth)
                return true;

            return false;
        }

        private Vector2 GetBorderDirection(Vector2 position)
        {
            var middle = _screen.Resolution / 2f;
            return (position - middle).normalized;
        }
    }
}