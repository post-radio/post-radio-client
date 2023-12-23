using System;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime.Abstract
{
    public interface IPoolObject
    {
        void Construct(Action<IPoolObject> returnToPool);
        GameObject GameObject { get; }

        void OnTaken();
        void OnReturned();
    }
}