using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Backend.Options
{
    [InlineEditor]
    public class BackendOptions : OptionsEntry
    {
        [SerializeField] private string _streamingApiUrl;

        public string StreamingApiUrl => _streamingApiUrl;
    }
}
