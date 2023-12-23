using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime.Abstract
{
    public interface IAsyncObjectProvider<T>
    {
        UniTask<T> Get(Vector2 position);
    }
}