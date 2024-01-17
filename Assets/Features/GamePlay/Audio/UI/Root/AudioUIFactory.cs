using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using GamePlay.Audio.UI.Overlay;
using GamePlay.Audio.UI.Voting.Runtime.Suggestion;
using GamePlay.Audio.UI.Voting.Runtime.Voting;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.UI.Root
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AudioRoutes.VotingName, menuName = AudioRoutes.VotingPath)]
    public class AudioUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private AudioOverlayConfig _overlayConfig;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<AudioOverlay>()
                .WithParameter(_overlayConfig)
                .AsCallbackListener();
            
            services.Register<VotingSession>()
                .As<IVotingSession>()
                .AsCallbackListener();
            
            services.Register<Suggestions>()
                .As<ISuggestions>()
                .AsCallbackListener();
            
            services.Register<AudioVoting>()
                .As<IAudioVoting>()
                .AsCallbackListener();

            services.Register<SuggestionController>()
                .AsCallbackListener();
        }
    }
}