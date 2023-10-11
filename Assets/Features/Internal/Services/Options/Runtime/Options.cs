using System.Collections.Generic;
using Internal.Services.Options.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Options", menuName = OptionRoutes.RootPath)]
    public class Options : ScriptableObject, IOptions
    {
        [SerializeField] private List<EnvironmentType> _optionsPriority;
        [SerializeField] private OptionsRegistriesDictionary _registries;

        public void Setup()
        {
            foreach (var (_, registry) in _registries)
                registry.CacheRegistry();
        }

        public T GetOptions<T>() where T : OptionsEntry
        {
            foreach (var environmentType in _optionsPriority)
            {
                var currentEnvironment = _registries[environmentType];

                if (currentEnvironment.TryGetEntry<T>(out var environmentEntry) == true)
                    return environmentEntry;
            }
            
            return null;
        }
    }
}