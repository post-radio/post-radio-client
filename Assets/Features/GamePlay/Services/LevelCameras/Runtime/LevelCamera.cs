using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using GamePlay.Services.LevelCameras.Logs;
using Global.Cameras.CurrentCameras.Runtime;
using Global.Inputs.View.Runtime.Projection;
using Global.System.ApplicationProxies.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class LevelCamera :
        MonoBehaviour,
        ILevelCamera,
        IPostFixedUpdatable,
        IScopeAwakeListener,
        IScopeSwitchListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            IInputProjection inputProjection,
            ILevelCameraConfig config,
            IUpdater updater,
            IScreen screen,
            LevelCameraLogger logger)
        {
            _screen = screen;
            _updater = updater;
            _config = config;
            _inputProjection = inputProjection;
            _logger = logger;
            _currentCamera = currentCamera;

            _transform = transform;
        }

        private const float _offsetZ = -10f;

        [SerializeField] [Min(0f)] private float _verticalSize = 8f; 
        [SerializeField] [Min(0f)] private float _horizontalSize = 6.34f; 
        
        private ICurrentCamera _currentCamera;

        private LevelCameraLogger _logger;

        private Transform _target;

        private Transform _transform;
        private IInputProjection _inputProjection;
        private ILevelCameraConfig _config;
        private IUpdater _updater;
        private IScreen _screen;

        public Camera Camera { get; private set; }

        public void OnAwake()
        {
            Camera = GetComponent<Camera>();
            _currentCamera.SetCamera(Camera);
        }
        
        public void OnEnabled()
        {
            _updater.Add(this);

            Camera.orthographicSize = _screen.ScreenMode switch
            {
                ScreenMode.Horizontal => _horizontalSize,
                ScreenMode.Vertical => _verticalSize,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
        }
        
        public void StartFollow(Transform target)
        {
            _target = target;

            _logger.OnStartFollow(target.name);
        }

        public void StopFollow()
        {
            if (_target == null)
            {
                _logger.OnStopFollowError();
                return;
            }

            _logger.OnStopFollow(_target.name);

            _target = null;
        }

        public void Teleport(Vector2 target)
        {
            var position = new Vector3(target.x, target.y, _offsetZ);
            _transform.position = position;

            _logger.OnTeleport(position);
        }

        public void SetSize(float size)
        {
            Camera.orthographicSize = size;
        }
        
        public void OnPostFixedUpdate(float delta)
        {
            if (_target == null)
                return;

            var targetPosition = _target.position;
            var line = _inputProjection.GetLineFrom(targetPosition);

            var distanceToCursor =
                line.Length - Vector2.Distance(targetPosition, _transform.position);

            var sight = _config.CreateSight(line.Direction, distanceToCursor);

            if (sight.IsOversight == true)
                targetPosition += sight.CreateOversightMove();

            var speed = _config.FollowSpeed * delta;
            var position = Vector3.Lerp(_transform.position, targetPosition, speed);
            position.z = _offsetZ;

            _transform.position = position;
        }
    }
}