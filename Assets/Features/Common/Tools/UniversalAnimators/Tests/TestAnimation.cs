using System;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Looped;

namespace Common.Tools.UniversalAnimators.Tests
{
    public class TestAnimation : LoopedAnimation
    {
        public TestAnimation(
            TestFrameEvent frameEvent,
            IFrameProvider frameProvider,
            AnimationData data) : base(frameProvider, data)
        {
            AddEventListener(frameEvent, InvokeTestEvent);
        }

        public event Action TestEvent;

        private void InvokeTestEvent()
        {
            TestEvent?.Invoke();   
        }
    }
}