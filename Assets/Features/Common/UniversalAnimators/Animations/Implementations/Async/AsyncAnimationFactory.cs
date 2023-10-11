using System.Collections.Generic;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Common.UniversalAnimators.Animations.Abstract;
using Common.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.UniversalAnimators.Animations.FrameSequence;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Common.UniversalAnimators.Animations.Implementations.Async
{
    public abstract class AsyncAnimationFactory : ScriptableObject
    {
        [SerializeField] [Indent] private AnimationData _data;

        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _frames = new();

        protected AnimationData Data => _data;
        protected IReadOnlyList<IFrameData> Frames => _frames;  

        public ForwardFrameProvider CreateFrameProvider()
        {
            return new ForwardFrameProvider(_frames);
        }

        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _sprites;
        [SerializeField] [FoldoutGroup("Create")]
        private string _animationName;

        [Button] [FoldoutGroup("Create")]
        private void CreateAnimation()
        {
            _frames.Clear();

            DeleteAll();
            
            for (var i = 0; i < _sprites.Length; i++)
            {
                var frame = CreateInstance<AnimationFrameData>();

                frame.name = $"{_animationName}_{i}";
                frame.Setup(_sprites[i]);
                
#if UNITY_EDITOR
                AssetDatabase.Refresh();
                AssetDatabase.AddObjectToAsset(frame, this);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
#endif

                _frames.Add(frame);
            }
        }

        [Button] [FoldoutGroup("Destroy")]
        private void DeleteAll()
        {
#if UNITY_EDITOR
            var path = AssetDatabase.GetAssetPath(this);
            var objects = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

            foreach (var target in objects)
                DestroyImmediate(target, true);
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }
    }
}