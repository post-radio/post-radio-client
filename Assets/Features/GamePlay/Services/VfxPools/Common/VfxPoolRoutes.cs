using GamePlay.Common.Paths;

namespace GamePlay.Services.VfxPools.Common
{
    public static class VfxPoolRoutes
    {
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "VfxPool";
        public const string ServicePath = GamePlayAssetsPaths.Root + "VfxPool/Service";

        public const string AnimatedName = "AnimatedVfx_";
        public const string AnimatedPath = GamePlayAssetsPaths.Root + "VfxPool/Animated";

        public const string ParticleName = "ParticleVfx_";
        public const string ParticlePath = GamePlayAssetsPaths.Root + "VfxPool/Particle";
    }
}