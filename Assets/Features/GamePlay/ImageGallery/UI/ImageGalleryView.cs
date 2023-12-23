using System.Threading;
using Cysharp.Threading.Tasks;
using Nova;
using UnityEngine;

namespace GamePlay.ImageGallery.UI
{
    [DisallowMultipleComponent]
    public class ImageGalleryView : MonoBehaviour, IImageGalleryView
    {
        [SerializeField] private UIBlock2D _block;
        [SerializeField] private UIBlock2D _blockNext;

        [SerializeField] [Min(0f)] private float _transitionTime = 2f;

        private CancellationTokenSource _cancellation;

        private void Awake()
        {
            Close();
        }

        public void Open()
        {
        }

        public void Close()
        {
            var color = Color.white;
            color.a = 0f;

            _block.Color = color;
            _blockNext.Color = color;

            _cancellation?.Cancel();
            _cancellation = new CancellationTokenSource();
        }

        public async UniTask SetImage(Texture2D image)
        {
            _cancellation?.Cancel();
            _cancellation = new CancellationTokenSource();
            
            var timer = 0f;
            var nextColor = Color.white;
            nextColor.a = 0f;

            _blockNext.SetImage(image);

            while (timer < _transitionTime)
            {
                nextColor.a = timer / _transitionTime;
                timer += Time.deltaTime;

                _blockNext.Color = nextColor;

                await UniTask.Yield(_cancellation.Token);
            }

            _block.SetImage(image);
            nextColor.a = 1f;
            _block.Color = nextColor;

            nextColor.a = 0f;
            _blockNext.Color = nextColor;
        }
    }
}