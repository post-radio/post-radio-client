using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.ImageGallery.Common
{
    [InlineEditor]
    public class ImageGalleryOptions : OptionsEntry
    {
        [SerializeField] [Min(0f)] private float _switchDelay;

        public float SwitchDelay => _switchDelay;
    }
}