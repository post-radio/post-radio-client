using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime.Abstract
{
    public interface IAsyncObjectFactory<T>
    {
        UniTask<T> Create(Vector2 position, float angle = 0f);
    }
}