using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Lifecycle.Common;
using UnityEngine;

namespace GamePlay.Network.Room.Lifecycle.Runtime
{
    [CreateAssetMenu(fileName = RoomStarterRoutes.ServiceName,
        menuName = RoomStarterRoutes.ServicePath)]
    public class RoomStarterFactory : RoomStarterBaseFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<RoomLifecycle>()
                .AsCallbackListener()
                .As<IRoomLifecycle>()
                .As<IRoomProvider>();
        }
    }
}