using System;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Internal.Services.Scenes.Logs;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Native
{
    public class NativeSceneLoader : ISceneLoader
    {
        public NativeSceneLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset)
        {
            var targetScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name != sceneAsset.Name)
                    return;

                targetScene = loadedScene;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            var handle = SceneManager.LoadSceneAsync(sceneAsset.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == sceneAsset.Name);

            _logger.OnSceneLoad(targetScene);

            var result = new NativeSceneLoadResult(targetScene);
            
            return result;
        }

        public async UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset)
        {
            var targetScene = new Scene();

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            {
                if (loadedScene.name != sceneAsset.Name)
                    return;

                targetScene = loadedScene;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            var handle = SceneManager.LoadSceneAsync(sceneAsset.Name, LoadSceneMode.Additive);
            var task = handle.ToUniTask();
            await task;

            await UniTask.WaitUntil(() => targetScene.name == sceneAsset.Name);

            _logger.OnSceneLoad(targetScene);

            var searched = Search<T>(targetScene);

            var result = new NativeSceneLoadTypedResult<T>(targetScene, searched);
            
            return result;
        }
        
        private T Search<T>(Scene scene)
        {
            var rootObjects = scene.GetRootGameObjects();
            foreach (var rootObject in rootObjects)
                if (rootObject.TryGetComponent(out T searched) == true)
                    return searched;
            throw new NullReferenceException($"Searched {typeof(T)} is not found");
        }
    }
}