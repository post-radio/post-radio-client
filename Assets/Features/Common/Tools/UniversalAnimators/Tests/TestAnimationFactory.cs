using System.Collections.Generic;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.FrameSequence;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Tests
{
    [CreateAssetMenu(fileName = "UniversalAnimation_TestFactory",
        menuName = "Common/UniversalAnimator/TestFactory")]
    public class TestAnimationFactory : ScriptableObject
    {
        [SerializeField] private AnimationData _data;
        [SerializeField] private TestFrameEvent _event;

        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _frames = new();

        public TestAnimation Create()
        {
            var frameProvider = new ForwardFrameProvider(_frames);
            var loopedAnimation = new TestAnimation(_event, frameProvider, _data);

            return loopedAnimation;
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