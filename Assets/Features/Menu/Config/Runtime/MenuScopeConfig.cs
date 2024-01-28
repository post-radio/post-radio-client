using System;
using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Services.LevelCameras.Runtime;
using Internal.Services.Scenes.Data;
using Menu.About.UI;
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
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = MenuAssetsPaths.Root + "Scene")]
    public class MenuScopeConfig : ScriptableObject, IScopeConfig
    {
        [FoldoutGroup("UI")] [SerializeField] private SettingsUIFactory _settings;
        [FoldoutGroup("UI")] [SerializeField] private MainUIFactory _main;
        [FoldoutGroup("UI")] [SerializeField] private AboutUIFactory _about;
        
        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;

        [FoldoutGroup("System")] [SerializeField]
        private BaseUiRootFactory _uiRoot;

        [FoldoutGroup("System")] [SerializeField]
        private StateMachineFactory _stateMachine;

        [FoldoutGroup("System")] [SerializeField]
        private MenuLoopFactory _loop;

        [FoldoutGroup("System")] [SerializeField]
        private MenuCameraFactory _camera;

        [SerializeField] private MenuScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _settings,
            _main,
            _about,
            _uiRoot,
            _stateMachine,
            _loop,
            _camera,
            _defaultCallbacks
        };

        public IReadOnlyList<IServicesCompose> Composes => Array.Empty<IServicesCompose>();
    }
}