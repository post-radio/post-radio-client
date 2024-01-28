using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
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