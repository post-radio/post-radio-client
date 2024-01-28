using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Listener.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Listener.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAudioListenerRoutes.ServiceName, menuName = GlobalAudioListenerRoutes.ServicePath)]
    public class GlobalAudioListenerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private GlobalGlobalAudioListener _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var switcher = Instantiate(_prefab);
            switcher.name = "AudioListener";
            utils.Binder.MoveToModules(switcher.gameObject);

            services.RegisterComponent(switcher)
                .As<IGlobalAudioListener>();
        }
    }
}