using Common.Architecture.DiContainer.Abstract;
using Menu.StateMachine.Definitions;
using Menu.StateMachine.Registry;

namespace Menu.StateMachine.Extensions
{
    public static class TabsExtensions
    {
        public static IRegistration AsTab<T>(this IRegistration registration, ITabDefinition tabDefinition)
            where T : ITab
        {
            registration.AsSelf();

            registration.Builder.Register<TabRegistrationHandler<T>>()
                .WithParameter(tabDefinition)
                .AsSelfResolvable();

            return registration;
        }

        public class TabRegistrationHandler<T> where T : ITab
        {
            public TabRegistrationHandler(T tab, ITabsRegistry tabsRegistry, ITabDefinition tabDefinition)
            {
                tabsRegistry.Register(tabDefinition, tab);
            }
        }
    }
}