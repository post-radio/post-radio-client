using Common.Architecture.DiContainer.Abstract;
using Common.Architecture.ObjectsPools.Runtime;
using Common.Architecture.ObjectsPools.Runtime.Abstract;
using GamePlay.Services.VfxPools.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ParticleName,
        menuName = VfxPoolRoutes.ParticlePath)]
    public class VfxParticleAsset : PoolEntryAsset
    {
        [SerializeField] [Indent] private VfxParticleObject _prefab;

        public override string Key => _prefab.name;
        public override string Name => _prefab.name;

        public override IObjectsPool Create(IServiceCollection builder, Transform parent)
        {
            var factory = new VfxObjectFactory<VfxParticleObject>(_prefab, parent);
            var provider = new ObjectProvider<VfxParticleObject>(factory, StartupInstances, parent);

            return provider;
        }
    }
}