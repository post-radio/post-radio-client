using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Scenes.Data
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Scene", menuName = "Internal/Scenes/Data")]
    public class SceneData : ScriptableObject, ISceneAsset
    {
        [SerializeField] private SceneField _name;
        [SerializeField] private SceneAssetReference _reference;

        public string Name => _name.SceneName;
        public SceneAssetReference Reference => _reference;
    }
}