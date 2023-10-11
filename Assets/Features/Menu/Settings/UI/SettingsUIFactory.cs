using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Settings.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Settings.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SettingsRoutes.ControllerName,
        menuName = SettingsRoutes.ControllerPath)]
    public class SettingsUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<SettingsController>()
                .As<ISettingsController>()
                .AsTab<SettingsController>(_tabDefinition);
        }
    }
}