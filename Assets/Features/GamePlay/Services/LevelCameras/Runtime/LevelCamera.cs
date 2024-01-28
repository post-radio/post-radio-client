using Common.Architecture.Scopes.Runtime.Callbacks;
using GamePlay.Services.LevelCameras.Logs;
using Global.Cameras.CurrentProvider.Runtime;
using Global.System.ApplicationProxies.Runtime;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public class LevelCamera :
        ILevelCamera,
        IScopeAwakeListener
    {
        public LevelCamera(
            Camera camera,
            ICurrentCameraProvider currentCameraProvider,
            IScreen screen,
            LevelCameraLogger logger)
        {
            _camera = camera;
            _screen = screen;
            _logger = logger;
            _currentCameraProvider = currentCameraProvider;

            _transform = camera.transform;
        }

        private const float _offsetZ = -10f;
        
        private readonly ICurrentCameraProvider _currentCameraProvider;
        private readonly LevelCameraLogger _logger;
        
        private readonly Transform _transform;
        private readonly Camera _camera;
        private readonly IScreen _screen;

        public Vector2 Position => _transform.position;
        public float Scale => Camera.orthographicSize;
        public float Aspect => _camera.aspect;
        public Camera Camera => _camera;

        public void OnAwake()
        {
            _currentCameraProvider.SetCamera(Camera);
        }

        public void SetPosition(Vector2 position)
        {
            _transform.position = new Vector3(position.x, position.y, _offsetZ);
            _logger.OnMove(position);
        }

        public void SetScale(float size)
        {
            Camera.orthographicSize = size;
            _logger.OnScale(size);
        }

        public void Disable()
        {
            _camera.enabled = false;
        }

        public void Enable()
        {
            _camera.enabled = true;
        }

        public void AddCameraToStack(Camera camera)
        {
            var stack = _camera.GetUniversalAdditionalCameraData().cameraStack;
            stack.Add(camera);  
        }
    }
}