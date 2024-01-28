using Common.Architecture.Scopes.Runtime;
using Cysharp.Threading.Tasks;

namespace Global.System.ScopeDisposer.Runtime
{
    public interface IScopeDisposer
    {
        public UniTask Unload(IScopeLoadResult scopeLoadResult);
    }
}