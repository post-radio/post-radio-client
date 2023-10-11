using VContainer;

namespace Common.Architecture.DiContainer.Abstract
{
    public interface IInjectionBuilder
    {
        void Inject(IObjectResolver resolver);
    }
}   