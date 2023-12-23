using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Audio.Player.Loading;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Player.Common
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.PlayerName, menuName = AudioRoutes.PlayerPath)]
    public class AudioPlayerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private AudioPlayerSource _sourcePrefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var source = Instantiate(_sourcePrefab);
            utils.Binder.MoveToModules(source);

            services.RegisterComponent(source)
                .As<IAudioPlayerSource>()
                .As<IAudioTimeProvider>();
            
            services.Register<LoadingAudioPlayer>()
                .As<IAudioPlayer>()
                .AsCallbackListener();
        }
    }
}