using UnityEngine;

namespace Global.Inputs.View.Runtime.Projection
{
    public interface IInputProjection
    {
        float GetAngleFrom(Vector2 from);
        Vector2 GetDirectionFrom(Vector2 from);
        LineResult GetLineFrom(Vector2 from);
    }
}