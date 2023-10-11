using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Starter.Common;
using UnityEngine;

namespace GamePlay.Network.Room.Starter.Runtime
{
    [CreateAssetMenu(fileName = RoomStarterRoutes.MockName,
        menuName = RoomStarterRoutes.MockPath)]
    public class MockRoomStarterFactory : RoomStarterBaseFactory
    {
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MockRoomStarter>()
                .AsCallbackListener();
        }
    }
}