using Common.Architecture.Container.Abstract;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityViewFactory
    {
        void CreateViews(IServiceCollection services, IEntityUtils utils);
    }
}