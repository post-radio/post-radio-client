using Nova;
using NovaSamples.UIControls;

namespace GamePlay.Audio.UI.Overlay
{
    public interface IAudioOverlayScheme
    {
        ProgressBar ProgressBar { get; }
        Slider AudioSlider { get; }
        Button VolumeButton { get; }
        UIBlock2D VolumeImage { get; }
        TextBlock SongDataText { get; }
    }
}