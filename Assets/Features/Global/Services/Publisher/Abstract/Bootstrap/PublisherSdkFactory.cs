using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Global.Publisher.Abstract.Bootstrap
{
    public abstract class PublisherSdkFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection builder, IScopeUtils utils);
    }
}