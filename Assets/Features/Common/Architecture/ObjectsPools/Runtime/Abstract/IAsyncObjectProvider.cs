using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IAsyncObjectProvider<T>
    {
        UniTask<T> Get(Vector2 position);
    }
}