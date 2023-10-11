using System;
using Common.UI.Buttons.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Buttons
{
    [Serializable]
    public class ImageSwitchButtonState : 
        IButtonState,
        IPointerEnterListener,
        IPointerExitListener,
        IPointerDownListener,
        IPointerUpListener
    {
        [SerializeField] private Image _image;

        [SerializeField] private Sprite _entered;
        [SerializeField] private Sprite _pressed;
        [SerializeField] private Sprite _exited;
        
        public void Construct(IButtonUtils utils)
        {
            OnPointerExit();
        }

        public void Dispose()
        {
        }

        public void OnPointerEnter()
        {
            _image.sprite = _entered;
        }

        public void OnPointerExit()
        {
            _image.sprite = _exited;
        }

        public void OnPointerDown()
        {
            _image.sprite = _pressed;
        }

        public void OnPointerUp()
        {
            _image.sprite = _entered;
        }
    }
}