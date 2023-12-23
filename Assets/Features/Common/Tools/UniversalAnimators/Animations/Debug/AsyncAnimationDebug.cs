using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Debug
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class AsyncAnimationDebug : MonoBehaviour
    {
        [SerializeField] private AsyncAnimationFactory _factory;

        private int _currentFrame;
        private SpriteRenderer _sprite;

        [ButtonGroup]
        [Button("<")]
        private void Previous()
        {
            Validate();

            _currentFrame--;

            var frameProvider = _factory.CreateFrameProvider();

            if (_currentFrame < 0)
                _currentFrame = frameProvider.FramesCount - 1;

            _sprite.sprite = frameProvider.GetFrame(_currentFrame).Sprite;
        }

        [ButtonGroup]
        [Button(">")]
        private void Next()
        {
            Validate();

            _currentFrame++;

            var frameProvider = _factory.CreateFrameProvider();

            if (_currentFrame >= frameProvider.FramesCount)
                _currentFrame = 0;

            _sprite.sprite = frameProvider.GetFrame(_currentFrame).Sprite;
        }

        private void Validate()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }
    }
}