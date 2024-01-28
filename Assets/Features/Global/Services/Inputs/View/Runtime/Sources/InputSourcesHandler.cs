using System.Collections.Generic;

namespace Global.Inputs.View.Runtime.Sources
{
    public class InputSourcesHandler : IInputSourcesHandler
    {
        private readonly List<IInputSource> _listeners = new();

        public void AddListener(IInputSource source)
        {
            _listeners.Add(source);
        }

        public void InvokeListen()
        {
            foreach (var listener in _listeners)
                listener.Listen();
        }

        public void Dispose()
        {
            foreach (var listener in _listeners)
                listener.UnListen();
        }
    }
}