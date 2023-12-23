using System.Collections.Generic;
using Common.Tools.UniversalAnimators.Animations.Events;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.FrameSequence
{
    public interface IFrameData
    {
        public Sprite Sprite { get; }
        public bool ContainsEvent { get; }
        public IReadOnlyList<FrameEvent> Events { get; }
    }
}