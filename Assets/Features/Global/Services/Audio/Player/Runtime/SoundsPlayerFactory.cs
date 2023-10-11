using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Player.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.ServiceName,
        menuName = AudioRoutes.ServicePath)]
    public class SoundsPlayerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SoundState _state;
        [SerializeField] private SoundsPlayer _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var player = Instantiate(_prefab);
            player.name = "SoundsPlayer";

            services.RegisterInstance(_state);

            services.RegisterComponent(player)
                .As<IVolumeSetter>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(player.gameObject);
        }
    }
}