using Common.UniversalAnimators.Animations.Implementations.Native;

namespace GamePlay.Player.Entity.Components.Location.Common
{
    public class HideAnimationFactory : NativeAnimationFactory
    {
        public HideAnimation Create()
        {
            return new HideAnimation(CreateData());
        }
    }
}