using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Factories.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Objects.Factories.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkObjectFactoryRoutes.DynamicFactoryName,
        menuName = NetworkObjectFactoryRoutes.DynamicFactoryPath)]
    public class DynamicEntityFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<DynamicEntityFactory>()
                .As<IDynamicEntityFactory>();
        }
    }
}