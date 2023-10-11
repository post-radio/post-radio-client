using Internal.Services.Scenes.Abstract;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Native
{
    public class NativeSceneLoadTypedResult<T> : ISceneLoadTypedResult<T>
    {
        public NativeSceneLoadTypedResult(Scene scene, T searched)
        {
            _scene = scene;
            Searched = searched;
        }
        
        private readonly Scene _scene;

        public T Searched { get; }
        public Scene Scene => _scene;
    }
}