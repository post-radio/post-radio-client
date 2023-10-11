using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Options.Implementations
{
    [InlineEditor]
    public class AssetsOptions : OptionsEntry
    {
        [SerializeField] private bool _useAddressables;

        public bool UseAddressables => _useAddressables;
    }
}