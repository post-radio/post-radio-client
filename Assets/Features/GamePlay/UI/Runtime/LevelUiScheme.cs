using GamePlay.Audio.UI.Overlay;
using GamePlay.Audio.UI.Voting.UI.Voting;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using GamePlay.ImageGallery.UI;
using Nova;
using UnityEngine;

namespace GamePlay.UI.Runtime
{
    [DisallowMultipleComponent]
    public class LevelUiScheme : MonoBehaviour, ILevelUiScheme
    {
        [SerializeField] private AudioOverlayScheme _audioOverlay;
        [SerializeField] private AudioVotingUIScheme _audioVoting;
        [SerializeField] private ImageGalleryScheme _imageGallery;
        [SerializeField] private ScreenSpace _screenSpace;
        
        public IAudioOverlayScheme AudioOverlay => _audioOverlay;
        public IVotingUIScheme AudioVoting => _audioVoting;
        public IImageGalleryScheme ImageGallery => _imageGallery;
        public ScreenSpace ScreenSpace => _screenSpace;
    }
}