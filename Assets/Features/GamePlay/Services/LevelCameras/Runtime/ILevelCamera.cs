using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public interface ILevelCamera
    {
        Vector2 Position { get; }
        float Scale { get; }
        float Aspect { get; }
        Camera Camera { get; }

        void SetPosition(Vector2 position);
        void SetScale(float size);
        void Disable();
        void Enable();
        void AddCameraToStack(Camera camera);
    }
}