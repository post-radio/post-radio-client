using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Inputs.Common;
using Global.Inputs.Constranits.Storage;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Global.Inputs.View.Runtime.Conversion;
using Global.Inputs.View.Runtime.Listeners;
using Global.Inputs.View.Runtime.Mouses;
using Global.Inputs.View.Runtime.Projection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputRouter.ServiceName,
        menuName = InputRouter.ServicePath)]
    public class InputViewFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private InputViewLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var controls = new Controls();
            var gamePlay = controls.GamePlay;

            services.Register<MouseInput>()
                .WithParameter(gamePlay)
                .As<IMouseInput>()
                .AsSelfResolvable();

            services.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            services.Register<InputConversion>()
                .As<IInputConversion>();

            services.Register<InputProjection>()
                .As<IInputProjection>();

            services.Register<InputView>()
                .WithParameter(controls)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            services.Register<InputActions>()
                .As<IInputActions>()
                .AsSelf()
                .AsSelfResolvable();

            services.Register<InputListenersHandler>()
                .As<IInputListenersHandler>();

            services.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>();
        }
    }
}