using Common.Architecture.Container.Abstract;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using UnityEngine;

namespace Common.Tools.ObjectsPools.Runtime
{
    public abstract class PoolEntryAsset : ScriptableObject, IPoolEntry
    {
        [SerializeField] [Min(1)] private int _startupInstances;

        public abstract string Key { get; }
        public abstract string Name { get; }

        protected int StartupInstances => _startupInstances;

        public abstract IObjectsPool Create(IServiceCollection builder, Transform parent);
    }
}