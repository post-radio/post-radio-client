using System;
using UnityEngine;

namespace Tools.AutoShorts.Runtime.SlideShow
{
    [Serializable]
    public class SlideData
    {
        public SlideData(Texture2D texture)
        {
            _texture = texture;
            _startScale = 0.9f;
            _endScale = 0.94f;
        }

        [SerializeField] private Texture2D _texture;
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private float _startScale;
        
        [SerializeField] private Vector2 _endPosition;
        [SerializeField] private float _endScale;

        public Texture2D Texture => _texture;
        
        public Vector2 StartPosition => _startPosition;
        public float StartScale => _startScale;
        
        public Vector2 EndPosition => _endPosition;
        public float EndScale => _endScale;

        public void SetStart(Vector2 startPosition, float startScale)
        {
            _startPosition = startPosition;
            _startScale = startScale;
        }

        public void SetEnd(Vector2 endPosition, float endScale)
        {
            _endPosition = endPosition;
            _endScale = endScale;
        }
    }
}