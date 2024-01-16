using System;
using Internal.Services.Options.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Backend.Options
{
    [InlineEditor]
    public class BackendOptions : OptionsEntry
    {
        [SerializeField] private BackendEnvironment _environment;
        
        [ShowIf("_environment", BackendEnvironment.Production)]
        [SerializeField] private string _productionApiUrl;
        [ShowIf("_environment", BackendEnvironment.Local)]
        [SerializeField] private string _localApiUrl;

        public string StreamingApiUrl
        {
            get
            {
                return _environment switch
                {
                    BackendEnvironment.Local => _localApiUrl,
                    BackendEnvironment.Production => _productionApiUrl,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }

    public enum BackendEnvironment
    {
        Local,
        Production
    }
}
