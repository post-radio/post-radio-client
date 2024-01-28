using System.Collections.Generic;

namespace Common.Architecture.Scopes.Runtime.Services
{
    public interface IServicesCompose
    {
        IReadOnlyList<IServiceFactory> Factories { get; }
    }
}