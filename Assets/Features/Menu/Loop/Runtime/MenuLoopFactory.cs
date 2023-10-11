using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Loop.Common;
using Menu.StateMachine.Definitions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoopRoutes.ServiceName,
        menuName = LoopRoutes.ServicePath)]
    public class MenuLoopFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private TabDefinition _mainDefinition;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<MenuLoop>()
                .WithParameter<ITabDefinition>(_mainDefinition)
                .AsCallbackListener();
        }
    }
}