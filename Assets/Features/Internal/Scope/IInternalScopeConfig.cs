using System.Collections.Generic;
using Internal.Abstract;
using Internal.Services.Options.Runtime;

namespace Internal.Scope
{
    public interface IInternalScopeConfig
    {
        InternalScope Scope { get; }
        IOptions Options { get; }
        IReadOnlyList<IInternalServiceFactory> Services { get; }
    }
}