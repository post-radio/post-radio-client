using Global.UI.Nova.Objects;
using Nova;
using UnityEngine;

namespace Global.UI.Nova.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextBlock))]
    public class TextButtonHandler : UIButtonHandler
    {
        [SerializeField] private ElementColors _colors;
            
        private TextBlock _block;
        
        private void Awake()
        {
            _block = GetComponent<TextBlock>();

            _block.Color = _colors.Idle;
        }
        
        public override void OnHover()
        {
            _block.Color = _colors.Hovered;
        }

        public override void OnUnhover()
        {
            _block.Color = _colors.Idle;
        }

        public override void OnPress()
        {
            _block.Color = _colors.Pressed;
        }

        public override void OnRelease()
        {
            _block.Color = _colors.Hovered;
        }

        public override void OnCancel()
        {
            _block.Color = _colors.Idle;
        }
    }
}