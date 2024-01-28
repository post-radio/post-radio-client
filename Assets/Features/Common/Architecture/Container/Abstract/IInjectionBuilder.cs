using VContainer;

namespace Common.Architecture.Container.Abstract
{
    public interface IInjectionBuilder
    {
        void Inject(IObjectResolver resolver);
    }
}   