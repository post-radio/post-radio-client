using System.Collections.Generic;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Architecture.ScopeLoaders.Runtime.Services;
using Internal.Services.Scenes.Data;
using Menu.Common.Paths;
using Menu.Loop.Runtime;
using Menu.Main.UI;
using Menu.Settings.UI;
using Menu.StateMachine.Runtime;
using Menu.UiRoot.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Menu.Config.Runtime
{
    [InlineEditor] [CreateAssetMenu(fileName = "Level", menuName = MenuAssetsPaths.Root + "Scene")]
    public class MenuConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("UI")] [SerializeField] private MainUIFactory _main;
        [FoldoutGroup("UI")] [SerializeField] private SettingsUIFactory _settings;
        
        [FoldoutGroup("System")] [SerializeField] private BaseUiRootFactory _uiRoot;
        [FoldoutGroup("System")] [SerializeField] private StateMachineFactory _stateMachine;
        [FoldoutGroup("System")] [SerializeField] private MenuLoopFactory _loop;
        
        [SerializeField] private MenuScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        
        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public IReadOnlyList<IServiceFactory> Services => GetFactories();
        public IReadOnlyList<ICallbacksFactory> Callbacks => GetCallbacks();
        
        private IServiceFactory[] GetFactories()
        {
            return new IServiceFactory[]
            {
                _main,
                _settings,
                _uiRoot,
                _stateMachine,
                _loop
            };
        }
        
        private ICallbacksFactory[] GetCallbacks()
        {
            return new ICallbacksFactory[]
            {
                new DefaultCallbacksFactory()
            };
        }
    }
}