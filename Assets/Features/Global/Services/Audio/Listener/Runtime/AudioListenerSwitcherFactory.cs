using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Listener.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Listener.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ListenerRoutes.ServiceName, menuName = ListenerRoutes.ServicePath)]
    public class AudioListenerSwitcherFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private AudioListenerSwitcher _prefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var switcher = Instantiate(_prefab);
            switcher.name = "AudioListener";
            utils.Binder.MoveToModules(switcher.gameObject);

            services.RegisterComponent(switcher)
                .As<IAudioListenerSwitcher>();
        }
    }
}