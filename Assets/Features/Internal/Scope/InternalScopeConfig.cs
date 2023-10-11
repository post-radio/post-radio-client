using System.Collections.Generic;
using Internal.Abstract;
using Internal.Common;
using Internal.Services.Loggers.Runtime;
using Internal.Services.Options.Runtime;
using Internal.Services.Scenes.Root;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Scope
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InternalRoutes.ConfigName, menuName = InternalRoutes.ConfigPath)]
    public class InternalScopeConfig : ScriptableObject, IInternalScopeConfig
    {
        [SerializeField] private ScenesFlowFactory _scenes;
        [SerializeField] private LoggerFactory _logger;
        [SerializeField] private Options _options;
        [SerializeField] private InternalScope _scope;

        public InternalScope Scope => _scope;
        public IOptions Options => _options;
        public IReadOnlyList<IInternalServiceFactory> Services => GetServices();

        private IReadOnlyList<IInternalServiceFactory> GetServices()
        {
            return new IInternalServiceFactory[]
            {
                _scenes,
                _logger
            };
        }
    }
}