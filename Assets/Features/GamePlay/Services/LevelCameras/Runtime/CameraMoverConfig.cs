using GamePlay.Services.LevelCameras.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelCameraRoutes.ConfigName, menuName = LevelCameraRoutes.ConfigPath)]
    public class CameraMoverConfig : ScriptableObject
    {
        [SerializeField] [Min(0f)] private float _zoomSensitivity;
        [SerializeField] [Min(0f)] private float _moveSensitivity;
        [SerializeField] [Min(0f)] private float _minZoom;
        [SerializeField] [Min(0f)] private float _maxZoom;
        [SerializeField] [Min(0f)] private float _screenBordersWidth;

        public float ZoomSensitivity => _zoomSensitivity;
        public float MoveSensitivity => _moveSensitivity;
        public float MinZoom => _minZoom;
        public float MaxZoom => _maxZoom;
        public float ScreenBordersWidth => _screenBordersWidth;
    }
}