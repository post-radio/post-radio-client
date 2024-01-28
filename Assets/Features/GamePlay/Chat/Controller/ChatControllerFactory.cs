using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Chat.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Chat.Controller
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ChatRoutes.ControllerName, menuName = ChatRoutes.ControllerPath)]
    public class ChatControllerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ChatController>()
                .As<IChatController>()
                .AsCallbackListener();
        }
    }
}