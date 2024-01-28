using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.PropertiesBinders.Runtime;
using Ragon.Client;

namespace GamePlay.Player.Entity.Components.Common
{
    public static class PropertiesExtensions
    {
        public static IRegistration AsProperty<T>(this IRegistration registration) where T : RagonProperty
        {
            registration.AsSelf();

            registration.Builder.Register<PropertyRegistrationHandler<T>>()
                .AsSelfResolvable();

            return registration;
        }

        public class PropertyRegistrationHandler<T> where T : RagonProperty
        {
            public PropertyRegistrationHandler(T property, IPropertyBinder binder)
            {
                binder.AddProperty(property);
            }
        }
    }
}