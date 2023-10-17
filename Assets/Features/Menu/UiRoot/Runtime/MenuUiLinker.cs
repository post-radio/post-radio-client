using Menu.About.UI;
using Menu.Main.UI;
using Menu.Settings.UI;
using Menu.StateMachine.Runtime.Transition;
using UnityEngine;

namespace Menu.UiRoot.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUiLinker : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        
        [SerializeField] private SettingsView _settings;
        [SerializeField] private MainView _main;
        [SerializeField] private AboutView _about;
        [SerializeField] private TabTransitionsRegistry _tabTransitionPoints;

        public Transform Root => _root;
        
        public ISettingsView Settings => _settings;
        public IMainView Main => _main;
        public IAboutView About => _about;
        public ITransitionPointsRegistry TabTransitionPoints => _tabTransitionPoints;
    }
}