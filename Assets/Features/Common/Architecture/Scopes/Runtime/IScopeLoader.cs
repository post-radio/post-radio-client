using Cysharp.Threading.Tasks;

namespace Common.Architecture.Scopes.Runtime
{
    public interface IScopeLoader
    {
        UniTask<IScopeLoadResult> Load();
    }
}