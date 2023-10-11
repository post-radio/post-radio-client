using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using UnityEngine;

namespace Global.Audio.Listener.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioListenerSwitcher))]
    public class AudioListenerSwitcher : 
        MonoBehaviour,
        IAudioListenerSwitcher,
        IScopeAwakeListener
    {
        private AudioListener _listener;
        
        public void OnAwake()
        {
            _listener = GetComponent<AudioListener>();
            Enable();    
        }
        
        public void Enable()
        {
            _listener.enabled = true;
        }

        public void Disable()
        {
            _listener.enabled = false;
        }
    }
}