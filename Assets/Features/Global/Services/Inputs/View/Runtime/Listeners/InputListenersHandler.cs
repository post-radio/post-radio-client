using System.Collections.Generic;

namespace Global.Inputs.View.Runtime.Listeners
{
    public class InputListenersHandler : IInputListenersHandler
    {
        private readonly List<IInputListener> _listeners = new();

        public void AddListener(IInputListener listener)
        {
            _listeners.Add(listener);
        }

        public void InvokeListen()
        {
            foreach (var listener in _listeners)
                listener.Listen();
        }

        public void InvokeUnlisten()
        {
            foreach (var listener in _listeners)
                listener.UnListen();
        }
    }
}