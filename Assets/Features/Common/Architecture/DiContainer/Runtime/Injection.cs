using Common.Architecture.DiContainer.Abstract;
using UnityEngine;
using VContainer;

namespace Common.Architecture.DiContainer.Runtime
{
    public class Injection : IInjectionBuilder
    {
        public Injection(Object target)
        {
            _target = target;
        }

        private readonly Object _target;

        public void Inject(IObjectResolver resolver)
        {
            resolver.Inject(_target);
        }
    }
}