using Cysharp.Threading.Tasks;

namespace Common.Architecture.ScopeLoaders.Runtime
{
    public interface IScopeLoader
    {
        UniTask<IScopeLoadResult> Load();
    }
}