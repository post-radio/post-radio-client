using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
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