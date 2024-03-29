﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Common.Architecture.Entities.Runtime
{
    public interface IEntityCreator
    {
        IEntityConfig Config { get; }
        
        UniTask<T> Create<T>(EntitySetupView view, IReadOnlyList<IComponentFactory> runtimeFactories);
    }
}