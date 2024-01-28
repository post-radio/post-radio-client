using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Inputs.View.Common;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Global.Inputs.View.Runtime.Sources;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputViewRoutes.ServiceName,
        menuName = InputViewRoutes.ServicePath)]
    public class InputViewFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;
        [SerializeField] [Indent] private InputSourceFactory[] _sourceFactories;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var controls = new Controls();

            foreach (var sourceFactory in _sourceFactories)
                sourceFactory.Create(controls, services);
            
            services.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            services.Register<InputView>()
                .WithParameter(controls)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            services.Register<InputActions>()
                .As<IInputActions>()
                .AsSelf()
                .AsSelfResolvable();

            services.Register<InputSourcesHandler>()
                .As<IInputSourcesHandler>();
        }
    }
}