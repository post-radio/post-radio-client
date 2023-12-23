using UnityEngine;

namespace Global.UI.Nova.Components
{
    [DisallowMultipleComponent]
    public abstract class UIButtonHandler : MonoBehaviour
    {
        public abstract void OnHover();
        public abstract void OnUnhover();
        public abstract void OnPress();
        public abstract void OnRelease();
        public abstract void OnCancel();
    }
}