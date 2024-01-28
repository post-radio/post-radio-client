using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Common;
using Global.UI.EventSystems.Runtime;
using Global.UI.LoadingScreens.Runtime;
using Global.UI.Localizations.Runtime;
using Global.UI.Nova.Compose;
using Global.UI.Overlays.Runtime;
using Global.UI.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "UICompose", menuName = GlobalAssetsPaths.Root + "UI/Compose")]
    public class GlobalUICompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private LoadingScreenFactory _loadingScreen;
        [SerializeField] private LocalizationFactory _localization;
        [SerializeField] private GlobalOverlayFactory _globalOverlay;
        [SerializeField] private UiStateMachineFactory _uiStateMachine;
        [SerializeField] private EventSystemFactory _eventSystem;
        [SerializeField] private NovaCompose _nova;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _loadingScreen,
            _localization,
            _globalOverlay,
            _uiStateMachine,
            _eventSystem,
            _nova
        };
    }
}