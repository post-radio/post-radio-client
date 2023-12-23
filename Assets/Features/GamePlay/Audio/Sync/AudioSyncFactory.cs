using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Sync
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.SyncName, menuName = AudioRoutes.SyncPath)]
    public class AudioSyncFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AudioSetter>()
                .As<IAudioSetter>()
                .AsCallbackListener();

            services.Register<TimerSync>();
        }
    }
}