using UnityEngine;

namespace Global.Inputs.Utils.Runtime.Conversion
{
    public interface IInputConversion
    {
        Vector2 ScreenToWorld(Vector2 position);
    }
}