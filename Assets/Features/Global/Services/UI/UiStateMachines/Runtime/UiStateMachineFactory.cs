using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.UI.UiStateMachines.Common;
using Global.UI.UiStateMachines.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.UiStateMachines.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiStateMachineRouter.ServiceName,
        menuName = UiStateMachineRouter.ServicePath)]
    public class UiStateMachineFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private UiStateMachineLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<UiStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<UiStateMachine>()
                .As<IUiStateMachine>();
        }
    }
}