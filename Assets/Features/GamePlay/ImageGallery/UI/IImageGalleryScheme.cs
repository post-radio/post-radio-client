using NovaSamples.UIControls;

namespace GamePlay.ImageGallery.UI
{
    public interface IImageGalleryScheme
    {
        IImageGalleryView View { get; }
        ICurrentAudioView CurrentAudio { get; }
        Button SwitchButton { get; }
    }
}