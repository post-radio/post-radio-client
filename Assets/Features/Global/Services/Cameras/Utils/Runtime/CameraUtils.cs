using Global.Cameras.CurrentProvider.Runtime;
using Global.Cameras.Utils.Logs;
using UnityEngine;

namespace Global.Cameras.Utils.Runtime
{
    public class CameraUtils : ICameraUtils
    {
        public CameraUtils(ICurrentCameraProvider currentCameraProvider, CameraUtilsLogger logger)
        {
            _currentCameraProvider = currentCameraProvider;
            _logger = logger;
        }

        private readonly ICurrentCameraProvider _currentCameraProvider;
        private readonly CameraUtilsLogger _logger;

        public Vector2 ScreenToWorld(Vector2 screen)
        {
            if (_currentCameraProvider.Current == null)
            {
                _logger.OnNoCameraError();
                return Vector2.zero;
            }

            var world = (Vector2)_currentCameraProvider.Current.ScreenToWorldPoint(screen);

            _logger.OnScreenToWorld(screen, world);

            return world;
        }
    }
}