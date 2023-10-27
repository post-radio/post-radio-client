using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.EntityCreators.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "EntityCreatorFactory", menuName = "Global/Common/EntityCreator")]
    public class EntityCreatorServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EntityCreatorFactory>()
                .As<IEntityCreatorFactory>();
        }
    }
}