using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace Common.Architecture.ObjectsPools.Runtime
{
    public interface IPoolEntry
    {
        public string Key { get; }
        public string Name { get; }

        public IObjectsPool Create(IServiceCollection builder, Transform parent);
    }
}