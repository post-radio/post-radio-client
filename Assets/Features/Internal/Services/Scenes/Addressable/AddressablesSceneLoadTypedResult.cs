using Internal.Services.Scenes.Abstract;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Addressable
{
    public class AddressablesSceneLoadTypedResult<T> : ISceneLoadTypedResult<T>, ISceneInstanceProvider
    {
        public AddressablesSceneLoadTypedResult(SceneInstance scene, T searched)
        {
            _scene = scene;
            Searched = searched;
        }

        private readonly SceneInstance _scene;

        public T Searched { get; }
        public Scene Scene => _scene.Scene;
        public SceneInstance SceneInstance => _scene;

        public bool TryGetSceneInstance(out SceneInstance scene)
        {
            scene = _scene;
            return true;
        }
    }
}