using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;
using Global.Inputs.Constranits.Definition;

namespace Global.Inputs.Constranits.Runtime
{
    [Serializable]
    public class InputConstraintsDictionary : ReadOnlyDictionary<InputConstraints, bool>
    {
    }
}