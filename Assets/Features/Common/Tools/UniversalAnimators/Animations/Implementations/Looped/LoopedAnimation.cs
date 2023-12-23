using System;
using System.Collections.Generic;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Events;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Looped
{
    public class LoopedAnimation : ILoopedAnimation
    {
        public LoopedAnimation(IFrameProvider frameProvider, AnimationData data)
        {
            _frameProvider = frameProvider;
            _framesCount = _frameProvider.FramesCount;
            _step = data.Time / _framesCount;

            Data = data;
        }

        private readonly IFrameProvider _frameProvider;

        private readonly Dictionary<FrameEvent, Action> _eventListeners = new();

        private readonly float _step;
        private readonly int _framesCount;

        private float _time;
        private int _previousFrameIndex;

        public AnimationData Data { get; }

        public Sprite Update(float delta)
        {
            var frameIndex = Mathf.FloorToInt(_time / _step);

            if (frameIndex >= _framesCount)
            {
                frameIndex = 0;
                _previousFrameIndex = -1;
                _time = 0f;
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

        public void Play()
        {
            _time = 0f;
            _previousFrameIndex = -1;
        }

        protected void AddEventListener(FrameEvent frameEvent, Action listener)
        {
            _eventListeners.Add(frameEvent, listener);
        }
    }
}