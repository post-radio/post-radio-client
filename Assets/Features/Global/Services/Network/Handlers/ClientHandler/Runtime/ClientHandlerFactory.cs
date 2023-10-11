using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Handlers.ClientHandler.Common;
using Ragon.Client.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Handlers.ClientHandler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ClientHandlerRoutes.ServiceName, menuName = ClientHandlerRoutes.ServicePath)]
    public class ClientHandlerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private RagonConfiguration _configuration;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<ClientFactory>()
                .WithParameter(_configuration.Type)
                .WithParameter(_configuration.Rate)
                .As<IClientFactory>();

            services.Register<ClientHandler>()
                .As<IClientProvider>()
                .AsCallbackListener();

            services.Register<RoomProvider>()
                .As<IRoomProvider>();
        }
    }
}