using VContainer;

namespace Common.Architecture.DiContainer.Abstract
{
    public interface IRegistrationBuilder
    {
        void Register(IContainerBuilder builder);
        void Resolve(IObjectResolver resolver);
        void ResolveWithCallbacks(IObjectResolver resolver, ICallbackRegister callbackRegister);
    }
}