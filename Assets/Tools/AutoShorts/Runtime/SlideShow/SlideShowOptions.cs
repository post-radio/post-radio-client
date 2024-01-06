using System;
using UnityEngine;

namespace Tools.AutoShorts.Runtime.SlideShow
{
    [Serializable]
    public class SlideShowOptions
    {
        public SlideShowOptions(float imageTime, float transitionTime)
        {
            _transitionTime = transitionTime;
            _imageTime = imageTime;
        }
        
        [SerializeField] private float _imageTime;
        [SerializeField] private float _transitionTime;

        public float ImageTime => _imageTime;
        public float TransitionTime => _transitionTime;
    }
}