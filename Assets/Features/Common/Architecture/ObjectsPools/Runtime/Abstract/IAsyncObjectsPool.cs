using Cysharp.Threading.Tasks;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IAsyncObjectsPool
    {
        IAsyncObjectProvider<T> GetProvider<T>();
        UniTask Preload();
        UniTask Unload();
    }
}