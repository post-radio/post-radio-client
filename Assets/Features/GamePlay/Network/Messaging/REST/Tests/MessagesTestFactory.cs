using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Network.Messaging.REST.Tests
{
    public class MessagesTestFactory : IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var view = Object.FindFirstObjectByType<MessagesTestView>();
            
            services.RegisterComponent(view)
                .AsCallbackListener()
                .AsSelfResolvable()
                .AsSelf();
        }
    }
}