using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Controller
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ControllerName, menuName = AudioRoutes.ControllerPath)]
    public class AudioControllerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AudioController>()
                .As<IAudioController>()
                .AsCallbackListener();
        }
    }
}