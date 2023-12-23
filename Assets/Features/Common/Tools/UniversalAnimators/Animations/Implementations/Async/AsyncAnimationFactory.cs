using System.Collections.Generic;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.FrameSequence;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Async
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