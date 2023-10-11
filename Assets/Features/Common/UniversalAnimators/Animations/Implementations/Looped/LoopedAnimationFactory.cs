using System.Collections.Generic;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Common.UniversalAnimators.Animations.Abstract;
using Common.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.UniversalAnimators.Animations.FrameSequence;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Common.UniversalAnimators.Animations.Implementations.Looped
{
    public abstract class LoopedAnimationFactory : ScriptableObject
    {
        [SerializeField] [Indent] private AnimationData _data;

        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _frames = new();

        protected AnimationData Data => _data;
        
        public IReadOnlyList<IFrameData> Frames => _frames;

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

            ConvertSprites(_sprites, _frames);
        }

        private void ConvertSprites(Sprite[] sprites, List<AnimationFrameData> target)
        {
#if UNITY_EDITOR
            Undo.RecordObject(this, "Add sprites");

            for (var i = 0; i < sprites.Length; i++)
            {
                AssetDatabase.Refresh();
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                var frame = CreateInstance<AnimationFrameData>();

                frame.name = $"{_animationName}_{i}";
                frame.Setup(sprites[i]);
                target.Add(frame);

                AssetDatabase.Refresh();
                AssetDatabase.AddObjectToAsset(frame, this);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Undo.RecordObject(this, "Add sprites");
#endif
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