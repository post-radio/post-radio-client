using Cysharp.Threading.Tasks;
using Menu.StateMachine.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Common.Navigation
{
    [DisallowMultipleComponent]
    public class TabNavigation : MonoBehaviour, ITabNavigation
    {
        [SerializeField] private NavigationDictionary _navigations;
        
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enable()
        {
            foreach (var (button, entry) in _navigations)
                button.Clicked += () => OnClicked(entry);
        }

        public void Disable()
        {
            foreach (var (button, _) in _navigations)
                button.UnsubscribeAll();
        }

        private void OnClicked(NavigationEntry entry)
        {
            _stateMachine.Select(entry.Definition, entry.Type).Forget();
        }
    }
}