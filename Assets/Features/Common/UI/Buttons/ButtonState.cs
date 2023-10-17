using UnityEngine;

namespace Common.UI.Buttons
{
    public abstract class ButtonState : MonoBehaviour
    {
        public abstract void Construct(IButtonUtils utils);
        public abstract void Dispose();
    }
}