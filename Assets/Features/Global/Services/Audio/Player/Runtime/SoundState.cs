using System;
using Global.Audio.Player.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [CreateAssetMenu(fileName = GlobalAudioRoutes.StateName, menuName = GlobalAudioRoutes.StatePath)]
    public class SoundState : ScriptableObject
    {
        [SerializeField] [ReadOnly] private bool _isMuted;

        public bool IsMuted => _isMuted;

        public event Action<bool> Changed;

        public void OnMuted()
        {
            _isMuted = true;

            Changed?.Invoke(_isMuted);
        }

        public void OnUnmuted()
        {
            _isMuted = false;

            Changed?.Invoke(_isMuted);
        }
    }
}