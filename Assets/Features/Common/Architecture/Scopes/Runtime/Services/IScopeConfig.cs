using System.Collections.Generic;
using Internal.Services.Scenes.Data;
using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface IScopeConfig
    {
        LifetimeScope ScopePrefab { get; }
        ISceneAsset ServicesScene { get; }

        IReadOnlyList<IServiceFactory> Services { get; }
        IReadOnlyList<IServicesCompose> Composes { get; }
    }
}