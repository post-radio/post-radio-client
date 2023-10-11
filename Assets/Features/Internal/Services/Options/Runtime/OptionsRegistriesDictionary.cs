using System;
using Common.Serialization.ReadOnlyDictionaries.Runtime;

namespace Internal.Services.Options.Runtime
{
    [Serializable]
    public class OptionsRegistriesDictionary : ReadOnlyDictionary<EnvironmentType, OptionsRegistry>
    {
    }
}