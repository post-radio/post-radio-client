using Common.Architecture.Container.Abstract;
using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Services.VfxPools.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.AnimatedName,
        menuName = VfxPoolRoutes.AnimatedPath)]
    public class VfxAnimatedAsset : PoolEntryAsset
    {
        [SerializeField] [Indent] private VfxAnimatedObject _prefab;

        public override string Key => _prefab.name;
        public override string Name => _prefab.name;

        public override IObjectsPool Create(IServiceCollection builder, Transform parent)
        {
            var factory = new VfxObjectFactory<VfxAnimatedObject>(_prefab, parent);
            var provider = new ObjectProvider<VfxAnimatedObject>(factory, StartupInstances, parent);

            return provider;
        }
    }
}