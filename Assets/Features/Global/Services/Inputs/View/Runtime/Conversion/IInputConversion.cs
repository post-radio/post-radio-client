using UnityEngine;

namespace Global.Inputs.View.Runtime.Conversion
{
    public interface IInputConversion
    {
        Vector2 ScreenToWorld(Vector2 position);
    }
}