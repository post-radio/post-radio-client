using Common.Architecture.DiContainer.Abstract;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.EntityCreators.Runtime
{
    public interface IComponentFactory
    {
        UniTask Create(IServiceCollection services, IEntityUtils utils);
    }
}