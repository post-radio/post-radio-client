using VContainer;

namespace Common.Architecture.Container.Abstract
{
    public interface IRegistrationBuilder
    {
        void Register(IContainerBuilder builder);
        void Resolve(IObjectResolver resolver);
        void ResolveWithCallbacks(IObjectResolver resolver, ICallbackRegister callbackRegister);
    }
}