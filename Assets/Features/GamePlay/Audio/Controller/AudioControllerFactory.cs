using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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