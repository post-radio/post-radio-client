using System.Collections.Generic;
using Common.UI.Buttons.Events;
using UnityEngine;

namespace Common.UI.Buttons
{
    public class ButtonEvents
    {
        private readonly List<IButtonUpdatable> _updateListeners = new();
        private readonly List<IPointerUpListener> _upListeners = new();
        private readonly List<IPointerDownListener> _downListeners = new();
        private readonly List<IPointerEnterListener> _enterListeners = new();
        private readonly List<IPointerExitListener> _exitListeners = new();
        private readonly List<IPointerHoverListener> _hoverListeners = new();
        
        public void Listen(object listener)
        {
            TryListen(listener, _updateListeners);
            TryListen(listener, _upListeners);
            TryListen(listener, _downListeners);
            TryListen(listener, _enterListeners);
            TryListen(listener, _exitListeners);
            TryListen(listener, _hoverListeners);
        }

        private void TryListen<T>(object listener, List<T> target)
        {
            if (listener is T value)
                target.Add(value);
        }

        public void InvokeUpdate()
        {
            foreach (var listener in _updateListeners)
                listener.UpdateState(Time.deltaTime);
        }
        
        public void InvokePointerUp()
        {
            foreach (var listener in _upListeners)
                listener.OnPointerUp();
        }

        public void InvokePointerDown()
        {
            foreach (var listener in _downListeners)
                listener.OnPointerDown();
        }

        public void InvokePointerEnter()
        {
            foreach (var listener in _enterListeners)
                listener.OnPointerEnter();
        }

        public void InvokePointerExit()
        {
            foreach (var listener in _exitListeners)
                listener.OnPointerExit();
        }

        public void InvokePointerHover(Vector2 position)
        {
            foreach (var listener in _hoverListeners)
                listener.OnPointerHover(position);
        }
    }
}