using System;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Data;
using Internal.Services.Scenes.Logs;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Addressable
{
    public class AddressablesSceneLoader : ISceneLoader
    {
        public AddressablesSceneLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset)
        {
            var scene = await Addressables.LoadSceneAsync(sceneAsset.Reference, LoadSceneMode.Additive)
                .ToUniTask();

            _logger.OnSceneLoad(scene.Scene);

            return new AddressablesSceneLoadResult(scene);
        }

        public async UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset)
        {
            var scene = await Addressables.LoadSceneAsync(sceneAsset.Reference, LoadSceneMode.Additive)
                .ToUniTask();

            _logger.OnSceneLoad(scene.Scene);

            var searched = Search<T>(scene.Scene);

            return new AddressablesSceneLoadTypedResult<T>(scene, searched);
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