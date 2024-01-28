using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Inputs.Utils.Common;
using Global.Inputs.Utils.Runtime.Conversion;
using Global.Inputs.Utils.Runtime.Projection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.Utils.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputUtilsRoutes.ServiceName, menuName = InputUtilsRoutes.ServicePath)]
    public class InputUtilsFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<InputConversion>()
                .As<IInputConversion>();

            services.Register<InputProjection>()
                .As<IInputProjection>();
        }
    }
}