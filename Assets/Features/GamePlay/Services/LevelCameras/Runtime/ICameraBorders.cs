using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    public interface ICameraBorders
    {
        Vector2 GetBordersOffset(Vector2 position, float scale, float aspect);
    }
}