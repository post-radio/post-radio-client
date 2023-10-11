using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Network.Session.Common;
using Global.Network.Session.Logs;
using Global.Network.Session.Runtime.Create;
using Global.Network.Session.Runtime.Join;
using Global.Network.Session.Runtime.Leave;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Session.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SessionRoutes.ServiceName,
        menuName = SessionRoutes.ServicePath)]
    public class SessionFlowFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private SessionLogSettings _logSettings;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<SessionLogger>()
                .WithParameter(_logSettings);
            
            services.Register<SessionCreate>()
                .As<ISessionCreate>();

            services.Register<SessionJoin>()
                .As<ISessionJoin>();

            services.Register<SessionLeave>()
                .As<ISessionLeave>();
        }
    }
}