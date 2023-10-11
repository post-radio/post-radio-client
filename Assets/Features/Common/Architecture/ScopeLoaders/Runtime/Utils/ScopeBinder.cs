using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Architecture.ScopeLoaders.Runtime.Utils
{
    public class ScopeBinder : IScopeBinder
    {
        private readonly Scene _scene;

        public ScopeBinder(Scene scene)
        {
            _scene = scene;
        }

        public void MoveToModules(MonoBehaviour service)
        {
            SceneManager.MoveGameObjectToScene(service.gameObject, _scene);
        }

        public void MoveToModules(GameObject gameObject)
        {
            SceneManager.MoveGameObjectToScene(gameObject, _scene);
        }

        public void MoveToModules(Transform transform)
        {
            SceneManager.MoveGameObjectToScene(transform.gameObject, _scene);
        }
    }
}