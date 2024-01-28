using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Settings.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Settings.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SettingsRoutes.ServiceName,
        menuName = SettingsRoutes.ServicePath)]
    public class SettingsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Settings>()
                .As<ISettings>();
        }
    }
}