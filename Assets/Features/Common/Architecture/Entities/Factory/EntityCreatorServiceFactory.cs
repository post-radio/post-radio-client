using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Architecture.Entities.Factory
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