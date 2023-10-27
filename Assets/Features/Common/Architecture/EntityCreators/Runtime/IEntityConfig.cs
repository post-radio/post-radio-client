using System.Collections.Generic;
using Common.Architecture.EntityCreators.Runtime.Callbacks;

namespace Common.Architecture.EntityCreators.Runtime
{
    public interface IEntityConfig
    {
        EntitySetupView Prefab { get; }

        IReadOnlyList<IComponentFactory> Components { get; }
        IReadOnlyList<ICallbacksFactory> Callbacks { get; }
    }
}