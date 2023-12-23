using System;
using UnityEngine;

namespace GamePlay.Audio.UI.Overlay
{
    [Serializable]
    public class AudioOverlayConfig
    {
        [SerializeField] private Sprite _enabledVolumeSprite;
        [SerializeField] private Sprite _disabledVolumeSprite;

        public Sprite EnabledVolumeSprite => _enabledVolumeSprite;
        public Sprite DisabledVolumeSprite => _disabledVolumeSprite;
    }
}