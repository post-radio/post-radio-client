using System;
using System.Collections.Generic;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Common.UniversalAnimators.Animations.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UniversalAnimators.Animations.FrameSequence
{
    [InlineEditor]
    [Serializable]
    public class AnimationFrameData : ScriptableObject, IFrameData
    {
        [SerializeField] 
        [PreviewField(100, ObjectFieldAlignment.Left)]
        [LabelWidth(40f)]
        [HorizontalGroup("Horizontal")]
        [BoxGroup("Horizontal/Sprite")]
        private Sprite _sprite;
        
        [SerializeField] 
        [LabelWidth(100f)]
        [HorizontalGroup("Horizontal")]
        [BoxGroup("Horizontal/Properties")]
        private bool _containsEvent;
        
        [SerializeField]
        [LabelWidth(40f)]
        [NestedScriptableObjectList]
        [ShowIf("_containsEvent")]
        [BoxGroup("Horizontal/Properties")]
        private List<FrameEvent> _events;

        public Sprite Sprite => _sprite;
        public bool ContainsEvent => _containsEvent;
        public IReadOnlyList<FrameEvent> Events => _events;

        public void Setup(Sprite sprite)
        {
            _sprite = sprite;
        }
    }
}