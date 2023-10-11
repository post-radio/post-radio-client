using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Common.Serialization.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using Global.System.Objects.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Objects.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ObjectsRoutes.ServiceName,
        menuName = ObjectsRoutes.ServicePath)]
    public class ObjectsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] private TestObjectAsset _asset;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            
        }
    }
}