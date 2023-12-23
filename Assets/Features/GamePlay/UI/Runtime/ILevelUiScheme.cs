using GamePlay.Audio.UI.Overlay;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using GamePlay.ImageGallery.UI;
using Nova;

namespace GamePlay.UI.Runtime
{
    public interface ILevelUiScheme
    {
        IAudioOverlayScheme AudioOverlay { get; }
        IVotingUIScheme AudioVoting { get; }
        IImageGalleryScheme ImageGallery { get; }
        ScreenSpace ScreenSpace { get; }
    }
}