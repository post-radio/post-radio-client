using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;

namespace Internal.Services.Options.Runtime
{
    [Serializable]
    public class OptionsRegistriesDictionary : ReadOnlyDictionary<EnvironmentType, OptionsRegistry>
    {
    }
}