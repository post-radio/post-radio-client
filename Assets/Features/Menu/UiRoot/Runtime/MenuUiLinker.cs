using Menu.Main.UI;
using Menu.Settings.UI;
using Menu.StateMachine.Runtime;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUiLinker : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        
        [SerializeField] private MainView _main;
        [SerializeField] private SettingsView _settings;
        [SerializeField] private TabTransitionsRegistry _tabTransitionPoints;

        public Transform Root => _root;
        
        public IMainView Main => _main;
        public ISettingsView Settings => _settings;
        public ITransitionPointsRegistry TabTransitionPoints => _tabTransitionPoints;
    }
}