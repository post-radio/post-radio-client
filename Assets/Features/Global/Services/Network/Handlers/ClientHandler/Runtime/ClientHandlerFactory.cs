using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ClientHandlerRoutes.ServiceName, menuName = ClientHandlerRoutes.ServicePath)]
    public class ClientHandlerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ClientFactory>()
                .As<IClientFactory>();

            services.Register<ClientHandler>()
                .As<IClientProvider>()
                .AsCallbackListener();
        }
    }
}