using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Chat.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Chat.InGame
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ChatRoutes.InGameName, menuName = ChatRoutes.InGamePath)]

    public class ChatInGameFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ChatInGame>()
                .As<IChatInGame>();
        }
    }
}