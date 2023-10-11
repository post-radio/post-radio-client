using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Abstract;
using Internal.Services.Scenes.Logs;
using UnityEngine.SceneManagement;

namespace Internal.Services.Scenes.Native
{
    public class NativeSceneUnloader : ISceneUnloader
    {
        public NativeSceneUnloader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask Unload(ISceneLoadResult result)
        {
            if (result == null)
                return;

            _logger.OnSceneUnload(result.Scene);
            var task = SceneManager.UnloadSceneAsync(result.Scene);

            await task.ToUniTask();
        }

        public async UniTask Unload(IReadOnlyList<ISceneLoadResult> results)
        {
            if (results == null || results.Count == 0)
                return;

            var tasks = new UniTask[results.Count];
            var scenes = new List<Scene>();

            foreach (var result in results)
                scenes.Add(result.Scene);

            foreach (var scene in scenes)
                _logger.OnSceneUnload(scene);

            for (var i = 0; i < scenes.Count; i++)
                tasks[i] = SceneManager.UnloadSceneAsync(scenes[i]).ToUniTask();

            await UniTask.WhenAll(tasks);
        }
    }
}