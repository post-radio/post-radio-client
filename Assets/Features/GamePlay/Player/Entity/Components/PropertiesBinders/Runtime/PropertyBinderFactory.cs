using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.EntityCreators.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.PropertiesBinders.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.PropertiesBinders.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PropertyBinderRoutes.ComponentName, menuName = PropertyBinderRoutes.ComponentPath)]
    public class PropertyBinderFactory : ScriptableObject, IComponentFactory
    {
        public async UniTask Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<PropertyBinder>()
                .As<IPropertyBinder>();
        }
    }
}