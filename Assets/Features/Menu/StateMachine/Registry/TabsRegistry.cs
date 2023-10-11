using System.Collections.Generic;
using Menu.StateMachine.Definitions;

namespace Menu.StateMachine.Registry
{
    public class TabsRegistry : ITabsRegistry
    {
        private readonly Dictionary<ITabDefinition, ITab> _tabs = new();

        public IReadOnlyList<ITab> GetAll()
        {
            var list = new List<ITab>();

            foreach (var (definition, tab) in _tabs)
                list.Add(tab);

            return list;
        }

        public void Register(ITabDefinition definition, ITab tab)
        {
            _tabs.Add(definition, tab);
        }

        public ITab GetTab(ITabDefinition definition)
        {
            return _tabs[definition];
        }
    }
}