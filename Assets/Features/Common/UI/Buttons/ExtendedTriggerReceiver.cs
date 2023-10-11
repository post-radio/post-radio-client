using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.Buttons
{
    public class ExtendedTriggerReceiver :
        MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        ITriggerReceiver
    {
        private bool _isInside;
        private bool _isLocked;

        public bool IsInside => _isInside;

        public event Action PointerEnter;
        public event Action PointerExit;
        public event Action PointerDown;
        public event Action PointerUp;

        public void Lock()
        {
            _isLocked = true;
            _isInside = false;
        }

        public void Unlock()
        {
            _isLocked = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;

            _isInside = true;
            PointerEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;

            _isInside = true;
            PointerExit?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;

            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;
            
            PointerUp?.Invoke();
        }
    }
}