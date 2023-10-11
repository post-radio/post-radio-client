using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Common;
using Global.Network.Connection.Logs;
using Ragon.Client.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Connection.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConnectionRoutes.ServiceName, menuName = ConnectionRoutes.ServicePath)]
    public class ConnectionFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private RagonConfiguration _configuration;
        [SerializeField] [Indent] private ConnectionLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var connectionConfig = new ConnectionConfig(
                _configuration.Address,
                _configuration.Protocol,
                _configuration.Port);

            services.Register<ConnectionLogger>()
                .WithParameter(_logSettings);

            services.Register<Connection>()
                .WithParameter(connectionConfig)
                .As<IConnection>();
        }
    }
}