using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Inputs.Constranits.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.Constranits.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputConstraintsRoutes.ServiceName, menuName = InputConstraintsRoutes.ServicePath)]
    public class InputConstraintsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<InputConstraintsStorage>()
                .As<IInputConstraintsStorage>()
                .AsCallbackListener();
        }
    }
}