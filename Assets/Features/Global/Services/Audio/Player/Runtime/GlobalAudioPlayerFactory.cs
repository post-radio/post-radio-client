using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAudioPlayerRoutes.ServiceName,
        menuName = GlobalAudioPlayerRoutes.ServicePath)]
    public class GlobalAudioPlayerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private GlobalAudioPlayer _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var player = Instantiate(_prefab);
            player.name = "AudioPlayer";

            services.RegisterComponent(player)
                .As<IGlobalVolume>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(player.gameObject);
        }
    }
}