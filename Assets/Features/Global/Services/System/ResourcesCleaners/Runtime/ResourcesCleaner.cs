using System;
using Cysharp.Threading.Tasks;
using Global.System.ResourcesCleaners.Logs;
using UnityEngine;

namespace Global.System.ResourcesCleaners.Runtime
{
    public class ResourcesCleaner : IResourcesCleaner
    {
        public ResourcesCleaner(ResourcesCleanerLogger logger)
        {
            _logger = logger;
        }

        private readonly ResourcesCleanerLogger _logger;

        public async UniTask CleanUp()
        {
            GC.Collect();

            await Resources.UnloadUnusedAssets().ToUniTask();

            _logger.OnCleaned();
        }
    }
}