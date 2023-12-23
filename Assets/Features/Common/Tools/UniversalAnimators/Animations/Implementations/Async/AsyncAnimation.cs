using System;
using System.Collections.Generic;
using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Async
{   
    public class AsyncAnimation : IAsyncAnimation
    {
        public AsyncAnimation(IFrameProvider frameProvider, AnimationData data)
        {
            _frameProvider = frameProvider;
            _framesCount = _frameProvider.FramesCount;

            if (data.Time == 0f)
                throw new ArgumentOutOfRangeException();
            
            _step = data.Time / _framesCount;

            Data = data;
        }
        
        private readonly IFrameProvider _frameProvider;
        
        private readonly Dictionary<FrameEvent, Action> _eventListeners = new();
        
        private readonly float _step;
        private readonly int _framesCount;

        private float _time;
        private int _previousFrameIndex;

        private UniTaskCompletionSource _completion;
        private bool _isCompleted;

        public AnimationData Data { get; }

        public Sprite Update(float delta)
        {
            if (_isCompleted == true)
                return _frameProvider.GetFrame(_framesCount - 1).Sprite;
            
            var frameIndex = Mathf.FloorToInt(_time / _step);

            if (frameIndex >= _framesCount)
            {
                frameIndex = _framesCount - 1;
                _time = 0f;
                _isCompleted = true;

                _completion.TrySetResult();
            }

            var frame = _frameProvider.GetFrame(frameIndex);

            if (frame.ContainsEvent == true && frameIndex != _previousFrameIndex)
            {
                foreach (var frameEvent in frame.Events)
                    _eventListeners[frameEvent]?.Invoke();
            }

            _previousFrameIndex = frameIndex;
            _time += delta;

            return frame.Sprite;
        }

        public async UniTask Play(CancellationToken cancellationToken)
        {
            _completion = new UniTaskCompletionSource();
            _isCompleted = false;
            _time = 0f;
            _previousFrameIndex = -1;

            cancellationToken.Register(OnCanceled);

            await _completion.Task;
        }

        private void OnCanceled()
        {
            _completion?.TrySetCanceled();
        }
        
        protected void AddEventListener(FrameEvent frameEvent, Action listener)
        {
            _eventListeners.Add(frameEvent, listener);
        }
    }
}