using Common.Architecture.Container.Abstract;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime
{
    public interface IPoolEntry
    {
        public string Key { get; }
        public string Name { get; }

        public IObjectsPool Create(IServiceCollection builder, Transform parent);
    }
}