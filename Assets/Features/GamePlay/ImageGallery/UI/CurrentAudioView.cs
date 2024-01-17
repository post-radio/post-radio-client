using Nova;
using UnityEngine;

namespace GamePlay.ImageGallery.UI
{
    [DisallowMultipleComponent]
    public class CurrentAudioView : MonoBehaviour, ICurrentAudioView
    {
        [SerializeField] private TextBlock _author;
        [SerializeField] private TextBlock _title;
        
        public void Construct(string author, string title)
        {
            _author.Text = author;
            _title.Text = title;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}