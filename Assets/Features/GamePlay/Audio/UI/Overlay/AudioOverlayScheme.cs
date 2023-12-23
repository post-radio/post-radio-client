using Nova;
using NovaSamples.UIControls;
using UnityEngine;

namespace GamePlay.Audio.UI.Overlay
{
    [DisallowMultipleComponent]
    public class AudioOverlayScheme : MonoBehaviour, IAudioOverlayScheme
    {
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private Slider _audioSlider;
        [SerializeField] private Button _volumeButton;
        [SerializeField] private UIBlock2D _volumeImage;
        [SerializeField] private TextBlock _songDataText;
        
        public ProgressBar ProgressBar => _progressBar;
        public Slider AudioSlider => _audioSlider;
        public Button VolumeButton => _volumeButton;
        public UIBlock2D VolumeImage => _volumeImage;
        public TextBlock SongDataText => _songDataText;
    }
}