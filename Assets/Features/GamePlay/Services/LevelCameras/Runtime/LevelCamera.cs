using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using GamePlay.Services.LevelCameras.Logs;
using Global.Cameras.CurrentCameras.Runtime;
using Global.System.ApplicationProxies.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class LevelCamera :
        MonoBehaviour,
        ILevelCamera,
        IScopeAwakeListener,
        IScopeEnableListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            IScreen screen,
            LevelCameraLogger logger)
        {
            _screen = screen;
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
        private IScreen _screen;

        public Vector2 Position => _transform.position;
        public float Scale => Camera.orthographicSize;
        public Camera Camera { get; private set; }

        public void OnAwake()
        {
            Camera = GetComponent<Camera>();
            _currentCamera.SetCamera(Camera);
        }
        
        public void OnEnabled()
        {
            Camera.orthographicSize = _screen.ScreenMode switch
            {
                ScreenMode.Horizontal => _horizontalSize,
                ScreenMode.Vertical => _verticalSize,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = new Vector3(position.x, position.y, _offsetZ);
            _logger.OnMove(position);
        }

        public void SetScale(float size)
        {
            Camera.orthographicSize = size;
            _logger.OnScale(size);
        }
    }
}