using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.UI.Common;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.Global
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ExtendedRoutes.ServiceName,
        menuName = ExtendedRoutes.ServicePath)]
    public class ExtendedFactory : ScriptableObject, IServiceFactory
    {   
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            
        }
    }
}