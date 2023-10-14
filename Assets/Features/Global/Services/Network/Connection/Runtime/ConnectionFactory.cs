using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Common;
using Global.Network.Connection.Configuration;
using Global.Network.Connection.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Connection.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConnectionRoutes.ServiceName, menuName = ConnectionRoutes.ServicePath)]
    public class ConnectionFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ConnectionLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var options = utils.Options.GetOptions<RagonConnectionOptions>();

            services.RegisterInstance(options)
                .As<IRagonConnectionOptions>();
            
            services.Register<ConnectionLogger>()
                .WithParameter(_logSettings);

            services.Register<Connection>()
                .As<IConnection>();
        }
    }
}