using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Logs;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Internal.Services.Scenes.Addressable
{
    public class AddressablesScenesUnloader : ISceneUnloader
    {
        public AddressablesScenesUnloader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask Unload(ISceneLoadResult result)
        {
            if (result == null)
                return;

            if (result is not ISceneInstanceProvider sceneInstanceProvider)
            {
                _logger.OnSceneUnloadFailed(result.Scene, "No SceneInstanceProviderFound");
                return;
            }

            _logger.OnSceneUnload(sceneInstanceProvider.SceneInstance.Scene);

            await Addressables.UnloadSceneAsync(sceneInstanceProvider.SceneInstance);
        }

        public async UniTask Unload(IReadOnlyList<ISceneLoadResult> results)
        {
            if (results == null || results.Count == 0)
                return;

            var tasks = new UniTask[results.Count];
            var scenes = new List<SceneInstance>();

            foreach (var result in results)
            {
                if (result is not ISceneInstanceProvider sceneInstanceProvider)
                {
                    _logger.OnSceneUnloadFailed(result.Scene, "No SceneInstanceProviderFound");
                    return;
                }

                scenes.Add(sceneInstanceProvider.SceneInstance);
            }

            foreach (var scene in scenes)
                _logger.OnSceneUnload(scene.Scene);

            for (var i = 0; i < scenes.Count; i++)
                tasks[i] = Addressables.UnloadSceneAsync(scenes[i]).ToUniTask();

            await UniTask.WhenAll(tasks);
        }
    }
}