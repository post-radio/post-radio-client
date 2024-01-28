using System.Collections.Generic;
using Common.Architecture.Entities.Factory;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Tools.UniversalAnimators.Updaters.Runtime;
using Global.Common;
using Global.System.ApplicationProxies.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.ResourcesCleaners.Runtime;
using Global.System.ScopeDisposer.Runtime;
using Global.System.Updaters.Setup;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalSystemCompose", menuName = GlobalAssetsPaths.Root + "System/Compose")]
    public class SystemCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private ScopeDisposerFactory _scopeDisposer;
        [SerializeField] private ApplicationProxyFactory _applicationProxy;
        [SerializeField] private MessageBrokerFactory _messageBroker;
        [SerializeField] private ResourcesCleanerFactory _resourcesCleaner;
        [SerializeField] private UpdaterFactory _updater;
        [SerializeField] private AnimatorsUpdaterFactory _animatorsUpdater;
        [SerializeField] private EntityCreatorServiceFactory _entityCreator;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _scopeDisposer,
            _applicationProxy,
            _messageBroker,
            _resourcesCleaner,
            _updater,
            _animatorsUpdater,
            _entityCreator
        };
    }
}