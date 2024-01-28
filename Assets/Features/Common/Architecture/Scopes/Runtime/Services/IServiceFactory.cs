using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface IServiceFactory
    {
        UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}