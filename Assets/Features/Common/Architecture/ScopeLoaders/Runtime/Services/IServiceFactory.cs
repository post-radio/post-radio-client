using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ScopeLoaders.Runtime.Utils;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime.Services
{
    public interface IServiceFactory
    {
        UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}