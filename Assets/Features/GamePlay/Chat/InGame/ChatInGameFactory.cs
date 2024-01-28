using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
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