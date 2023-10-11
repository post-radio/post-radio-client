using System.Collections.Generic;
using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Registry
{
    public interface ITabsRegistry
    {
        IReadOnlyList<ITab> GetAll();
        void Register(ITabDefinition definition, ITab tab);
        ITab GetTab(ITabDefinition definition);
    }
}