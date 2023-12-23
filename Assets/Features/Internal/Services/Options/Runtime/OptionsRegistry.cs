using System;
using System.Collections.Generic;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Internal.Services.Options.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "OptionsRegistry", menuName = OptionRoutes.RegistryPath)]
    public class OptionsRegistry : ScriptableObject
    {
        [SerializeField] [NestedScriptableObjectSet] private List<OptionsEntry> _options;

        private readonly Dictionary<Type, OptionsEntry> _entries = new();

        public void CacheRegistry()
        {
            _entries.Clear();
            
            foreach (var entry in _options)
            {
                var type = entry.GetType();
                _entries.Add(type, entry);
            }
        }
        
        public bool TryGetEntry<T>(out T value) where T : OptionsEntry
        {
            if (_entries.TryGetValue(typeof(T), out var result) == true)
            {
                value = result as T;

                return true;
            }

            value = null;
            return false;
        }
    }
}