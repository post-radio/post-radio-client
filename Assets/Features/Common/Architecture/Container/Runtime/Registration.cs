using System;
using Common.Architecture.Container.Abstract;
using VContainer;

namespace Common.Architecture.Container.Runtime
{
    public class Registration : IRegistration, IRegistrationBuilder
    {
        public Registration(RegistrationBuilder registration, Type type, IServiceCollection builder)
        {
            _registration = registration;
            _builder = builder;
            Type = type;
        }

        private readonly RegistrationBuilder _registration;
        private readonly IServiceCollection _builder;

        private bool _isListeningCallbacks;
        private bool _isSelfResolvable;

        public Type Type { get; }
        public IServiceCollection Builder => _builder;

        public IRegistration AsCallbackListener()
        {
            _isListeningCallbacks = true;
            _isSelfResolvable = true;

            return AsSelfResolvable();
        }

        public IRegistration AsSelf()
        {
            _registration.AsSelf();

            return this;
        }

        public IRegistration AsImplementedInterfaces()
        {
            _registration.AsImplementedInterfaces();

            return this;
        }

        public IRegistration AsSelfResolvable()
        {
            _isSelfResolvable = true;
            _registration.AsSelf();

            return this;
        }

        public IRegistration As<T>()
        {
            _registration.As<T>();

            return this;
        }

        public IRegistration WithParameter<T>(T value)
        {
            _registration.WithParameter(value);

            return this;
        }

        public void Register(IContainerBuilder builder)
        {
            builder.Register(_registration);
        }

        public void Resolve(IObjectResolver resolver)
        {
            if (_isSelfResolvable == false)
                return;

            resolver.Resolve(Type);
        }

        public void ResolveWithCallbacks(IObjectResolver resolver, ICallbackRegister callbackRegistry)
        {
            if (_isSelfResolvable == false)
                return;

            var registration = resolver.Resolve(Type);

            if (_isListeningCallbacks == true)
                callbackRegistry.Listen(registration);
        }
    }
}