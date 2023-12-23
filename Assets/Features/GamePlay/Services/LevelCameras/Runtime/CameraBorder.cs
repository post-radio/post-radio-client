using UnityEngine;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [DisallowMultipleComponent]
    public class CameraBorders : MonoBehaviour, ICameraBorders
    {
        [SerializeField] private Transform _leftBottom;
        [SerializeField] private Transform _rightTop;

        public Vector2 GetBordersOffset(Vector2 position, float scale, float aspect)
        {
            var halfHeight = scale;
            var halfWidth = aspect * halfHeight;

            var leftBottom = _leftBottom.position;
            var rightTop = _rightTop.position;

            var leftBottomPoint = new Vector2(position.x - halfWidth, position.y - halfHeight);
            var rightTopPoint = new Vector2(position.x + halfWidth, position.y + halfHeight);
            var rightBottomPoint = new Vector2(position.x + halfWidth, position.y - halfHeight);


            var diff = Vector2.zero;

            if (leftBottomPoint.x < leftBottom.x)
                diff.x = leftBottom.x - leftBottomPoint.x;

            if (rightBottomPoint.x > rightTop.x)
                diff.x = rightTop.x - rightBottomPoint.x;

            if (leftBottomPoint.y < leftBottom.y)
                diff.y = leftBottom.y - leftBottomPoint.y;

            if (rightTopPoint.y > rightTop.y)
                diff.y = rightTop.y - rightTopPoint.y;

            return diff;
        }
    }
}