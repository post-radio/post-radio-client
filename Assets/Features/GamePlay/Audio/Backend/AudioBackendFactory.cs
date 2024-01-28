using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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