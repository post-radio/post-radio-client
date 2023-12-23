using NovaSamples.UIControls;
using UnityEngine;

namespace GamePlay.ImageGallery.UI
{
    [DisallowMultipleComponent]
    public class ImageGalleryScheme : MonoBehaviour, IImageGalleryScheme
    {
        [SerializeField] private ImageGalleryView _view;
        [SerializeField] private CurrentAudioView _currentAudio;
        [SerializeField] private Button _switchButton;

        public IImageGalleryView View => _view;
        public ICurrentAudioView CurrentAudio => _currentAudio;
        public Button SwitchButton => _switchButton;
    }
}