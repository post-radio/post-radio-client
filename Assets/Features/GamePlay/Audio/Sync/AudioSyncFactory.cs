using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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
            services.Register<AudioSync>()
                .As<IAudioSync>()
                .AsCallbackListener();

            services.Register<TimerSync>();
        }
    }
}