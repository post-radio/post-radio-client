using Common.UniversalAnimators.Animations.Implementations.Native;

namespace GamePlay.Player.Entity.Components.Location.Common
{
    public class ShowAnimationFactory : NativeAnimationFactory
    {
        public ShowAnimation Create()
        {
            return new ShowAnimation(CreateData());
        }
    }
}