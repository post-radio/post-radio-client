using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using Global.Backend.Options;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Backend
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.BackendName, menuName = AudioRoutes.BackendPath)]
    public class AudioBackendFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var audioOptions = utils.Options.GetOptions<AudioOptions>();
            var backendOptions = utils.Options.GetOptions<BackendOptions>();
            
            services.RegisterInstance(audioOptions);
            services.RegisterInstance(audioOptions.Backend);
            services.RegisterInstance(audioOptions.Vote);
            
            var routes = new BackendRoutes(audioOptions, backendOptions);
            services.RegisterInstance(routes)
                .As<IBackendRoutes>();

            services.Register<AudioBackend>()
                .As<IAudioBackend>()
                .AsCallbackListener();
        }
    }
}