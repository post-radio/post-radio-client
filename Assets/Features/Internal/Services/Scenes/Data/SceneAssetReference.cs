using System;
using UnityEditor;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Internal.Services.Scenes.Data
{
    [Serializable]
    public class SceneAssetReference : AssetReference
    {
        public SceneAssetReference(string guid) : base(guid)
        {
        }

        public override bool ValidateAsset(Object obj)
        {
#if UNITY_EDITOR
            var type = obj.GetType();
            return typeof(SceneAsset).IsAssignableFrom(type);
#else
            return false;
#endif
        }

        public override bool ValidateAsset(string path)
        {
#if UNITY_EDITOR
            var type = AssetDatabase.GetMainAssetTypeAtPath(path);
            return typeof(SceneAsset).IsAssignableFrom(type);
#else
            return false;
#endif
        }

#if UNITY_EDITOR
        public SceneAsset _editorAsset => (SceneAsset)base.editorAsset;
#endif
    }
}