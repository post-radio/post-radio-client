using System.Collections.Generic;
using Common.Architecture.Entities.Runtime.Callbacks;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityConfig
    {
        EntitySetupView Prefab { get; }

        IReadOnlyList<IComponentFactory> Components { get; }
        IReadOnlyList<ICallbacksFactory> Callbacks { get; }
    }
}