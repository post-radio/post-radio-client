using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public interface ILevelCamera
    {
        Vector2 Position { get; }
        float Scale { get; }
        Camera Camera { get; }

        void SetPosition(Vector2 position);
        void SetScale(float size);
    }
}