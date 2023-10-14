using Common.Architecture.DiContainer.Abstract;
using VContainer;

namespace Common.Architecture.DiContainer.Runtime
{
    public class Injection : IInjectionBuilder
    {
        public Injection(object target)
        {
            _target = target;
        }

        private readonly object _target;

        public void Inject(IObjectResolver resolver)
        {
            resolver.Inject(_target);
        }
    }
}