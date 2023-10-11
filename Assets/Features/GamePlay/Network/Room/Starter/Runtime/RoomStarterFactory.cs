using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Starter.Common;
using UnityEngine;

namespace GamePlay.Network.Room.Starter.Runtime
{
    [CreateAssetMenu(fileName = RoomStarterRoutes.ServiceName,
        menuName = RoomStarterRoutes.ServicePath)]
    public class RoomStarterFactory : RoomStarterBaseFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<RoomStarter>()
                .AsCallbackListener();
        }
    }
}