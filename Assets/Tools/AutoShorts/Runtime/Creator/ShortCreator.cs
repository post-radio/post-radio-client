using System.Collections.Generic;
using Nova;
using Sirenix.OdinInspector;
using Tools.AutoShorts.Runtime.SlideShow;
using UnityEngine;

namespace Tools.AutoShorts.Runtime
{
    [DisallowMultipleComponent]
    public class ShortCreator : MonoBehaviour, IShortCreator
    {
        [SerializeField] private string _audioURL;
        [SerializeField] private float _startOffset;
        [SerializeField] private float _audioLength;

        [SerializeField] private float _imageTransitionPercent;
        [SerializeField] private Texture2D[] _images;

        [SerializeField] private UIBlock2D[] _blocks;
        [SerializeField] private SlideShowOptions _slideShowOptions;
        [SerializeField] private List<SlideData> _slides;

        [SerializeField] private int _imageIndex;

        public AudioOptions AudioOptions => new(_audioURL, _startOffset, _audioLength);
        public SlideShowOptions SlideShowOptions => _slideShowOptions;
        public IReadOnlyList<SlideData> Slides => _slides;

        [Button]
        private void ReloadCurrent()
        {
            var blockTransform = _blocks[_imageIndex].transform;
            blockTransform.localPosition = Vector3.zero;
            blockTransform.localScale = Vector3.one;

            var image = _images[_imageIndex];
            var slide = new SlideData(image);
            _slides[_imageIndex] = slide;

            foreach (var tmpBlock in _blocks)
                tmpBlock.gameObject.SetActive(false);

            var block = _blocks[_imageIndex];
            block.gameObject.SetActive(true);
            block.SetImage(slide.Texture);
        }

        [Button]
        private void NextImage()
        {
            _imageIndex++;

            if (_imageIndex >= _images.Length)
                _imageIndex = 0;

            if (_slides.Count <= _imageIndex)
            {
                var blockTransform = _blocks[_imageIndex].transform;
                blockTransform.localPosition = Vector3.zero;
                blockTransform.localScale = Vector3.one;

                var image = _images[_imageIndex];
                var newSlide = new SlideData(image);
                _slides.Add(newSlide);
            }

            var slide = _slides[_imageIndex];

            foreach (var tmpBlock in _blocks)
                tmpBlock.gameObject.SetActive(false);

            var block = _blocks[_imageIndex];
            block.gameObject.SetActive(true);
            block.SetImage(slide.Texture);
        }

        [Button]
        private void ResetStart()
        {
            var blockTransform = _blocks[_imageIndex].transform;
            blockTransform.localPosition = Vector3.zero;
            blockTransform.localScale = Vector3.one;

            var slide = _slides[_imageIndex];
            slide.SetStart(Vector3.zero, 1f);
        }

        [Button]
        private void ResetEnd()
        {
            var blockTransform = _blocks[_imageIndex].transform;
            blockTransform.localPosition = Vector3.zero;
            blockTransform.localScale = Vector3.one;

            var slide = _slides[_imageIndex];
            slide.SetEnd(Vector3.zero, 1f);
        }

        [Button]
        private void RecordStart()
        {
            var blockTransform = _blocks[_imageIndex].transform;
            var slide = _slides[_imageIndex];
            slide.SetStart(blockTransform.localPosition, blockTransform.localScale.x);
        }

        [Button]
        private void RecordEnd()
        {
            var blockTransform = _blocks[_imageIndex].transform;
            var slide = _slides[_imageIndex];
            slide.SetEnd(blockTransform.localPosition, blockTransform.localScale.x);
        }

        [Button]
        private void GenerateOptions()
        {
            var imagesCount = _images.Length;
            var imageTime = _audioLength / imagesCount;
            var transitionTime = _imageTransitionPercent / 100f * imageTime;
            _slideShowOptions = new SlideShowOptions(imageTime, transitionTime);
        }
    }
}