using System;
using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime.Abstract
{
    public interface IPoolObject
    {
        void Construct(Action<IPoolObject> returnToPool);
        GameObject GameObject { get; }

        void OnTaken();
        void OnReturned();
    }
}