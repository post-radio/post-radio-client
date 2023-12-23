using GamePlay.Audio.Definitions;

namespace GamePlay.ImageGallery.UI
{
    public interface ICurrentAudioView
    {
        void Construct(string author, string title);
        void Show();
        void Hide();
    }
}