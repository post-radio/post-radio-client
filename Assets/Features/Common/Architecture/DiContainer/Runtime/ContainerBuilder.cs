using System;
using System.Collections.Generic;
using Common.Architecture.DiContainer.Abstract;
using UnityEngine;
using VContainer;
using VContainer.Internal;
using VContainer.Unity;

namespace Common.Architecture.DiContainer.Runtime
{
    public class ContainerBuilder : IServiceCollection, IDependenciesBuilder
    {
        private readonly List<IInjectionBuilder> _injections = new();
        private readonly List<IRegistrationBuilder> _registrations = new();

        public void RegisterAll(IContainerBuilder builder)
        {
            foreach (var registration in _registrations)
                registration.Register(builder);
        }

        public void ResolveAll(IObjectResolver resolver)
        {
            foreach (var registration in _registrations)
                registration.Resolve(resolver);

            foreach (var injection in _injections)
                injection.Inject(resolver);
        }

        public void ResolveAllWithCallbacks(IObjectResolver resolver, ICallbackRegister callbackRegistry)
        {
            foreach (var registration in _registrations)
                registration.ResolveWithCallbacks(resolver, callbackRegistry);
            
            foreach (var injection in _injections)
                injection.Inject(resolver);
        }

        public IRegistration Register<T>()
        {
            var type = typeof(T);
            var builder = new RegistrationBuilder(type, Lifetime.Singleton);
            var registration = new Registration(builder, type, this);
            
            _registrations.Add(registration);

            return registration;
        }

        public IRegistration RegisterInstance<T>(T instance)
        {
            var builder = new InstanceRegistrationBuilder(instance).As(typeof(T));
            var registration = new Registration(builder, typeof(T), this);
            _registrations.Add(registration);

            return registration;
        }

        public IRegistration RegisterComponent<T>(T component) where T : MonoBehaviour
        {
            var builder = new ComponentRegistrationBuilder(component);
            var registration = new Registration(builder, typeof(T), this);

            _registrations.Add(registration);

            return registration;
        }

        public void Inject<T>(T component)
        {
            if (component == null)
                throw new NullReferenceException("No component provided");
            
            var injection = new Injection(component);

            _injections.Add(injection);
        }
    }
}