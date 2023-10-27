using Common.Architecture.DiContainer.Abstract;

namespace Common.Architecture.EntityCreators.Runtime
{
    public interface IEntityViewFactory
    {
        void CreateViews(IServiceCollection services, IEntityUtils utils);
    }
}