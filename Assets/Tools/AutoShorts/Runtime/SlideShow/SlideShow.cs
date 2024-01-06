using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nova;
using UnityEngine;

namespace Tools.AutoShorts.Runtime.SlideShow
{
    public class SlideShow : MonoBehaviour, ISlideShow
    {
        [SerializeField] private UIBlock2D[] _images;

        public void Play(SlideShowOptions options, IReadOnlyList<SlideData> slides)
        {
            foreach (var tmpBlock in _images)
                tmpBlock.gameObject.SetActive(false);
            
            Process(options, slides).Forget();
        }

        private async UniTask Process(SlideShowOptions options, IReadOnlyList<SlideData> slides)
        {
            _images[0].SetImage(slides[0].Texture);
            _images[0].gameObject.SetActive(true);
            var color = Color.white;
            color.a = 1f;
            _images[0].Color = color;

            var switchDelay = options.ImageTime - options.TransitionTime;
            var cancellation = new CancellationTokenSource();
            
            Move(options, _images[0], slides[0], cancellation.Token).Forget();

            for (var i = 1; i < slides.Count; i++)
            {
                Debug.Log($"Delay: {switchDelay}");
                await UniTask.Delay(switchDelay);
                cancellation.Cancel();
                cancellation = new CancellationTokenSource();

                var image = _images[i];
                var slide = slides[i];
                Debug.Log($"Switch");

                Switch(options, image, slide, cancellation.Token).Forget();
                Move(options, image, slide, cancellation.Token).Forget();
            }
        }

        private async UniTask Switch(
            SlideShowOptions options,
            UIBlock2D block,
            SlideData image,
            CancellationToken cancellation)
        {
            var timer = 0f;
            var color = Color.white;
            color.a = 0f;
            block.Color = color;
            block.SetImage(image.Texture);
            block.gameObject.SetActive(true);

            while (timer < options.TransitionTime)
            {
                color.a = timer / options.TransitionTime;
                timer += Time.deltaTime;

                block.Color = color;

                await UniTask.Yield(cancellation);
            }

            color.a = 1f;
            block.Color = color;
        }

        private async UniTask Move(
            SlideShowOptions options,
            UIBlock2D block,
            SlideData data,
            CancellationToken cancellation)
        {
            var progress = 0f;
            var timer = 0f;
            var blockTransform = block.transform;

            while (progress < 1f)
            {
                timer += Time.deltaTime;
                progress = timer / options.ImageTime;

                var scale = Mathf.Lerp(data.StartScale, data.EndScale, progress);
                var position = Vector3.Lerp(data.StartPosition, data.EndPosition, progress);

                blockTransform.localPosition = position;
                blockTransform.localScale = Vector3.one * scale;

                await UniTask.Yield(cancellation);
            }
        }
    }
}