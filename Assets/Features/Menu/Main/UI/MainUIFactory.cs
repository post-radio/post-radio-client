using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Main.Common;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MainRoutes.ControllerName,
        menuName = MainRoutes.ControllerPath)]
    public class MainUIFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _tabDefinition;
        [SerializeField] private TransitToGameConfig _config;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MainController>()
                .As<IMainController>()
                .WithParameter(_config)
                .AsCallbackListener()
                .AsTab<MainController>(_tabDefinition);
        }
    }
}