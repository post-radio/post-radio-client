using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Room.Entities.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneEntityFactoryRoutes.ServiceName,
        menuName = SceneEntityFactoryRoutes.ServicePath)]
    public class SceneEntityFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<SceneEntityFactory>()
                .As<ISceneEntityFactory>();
        }
    }
}