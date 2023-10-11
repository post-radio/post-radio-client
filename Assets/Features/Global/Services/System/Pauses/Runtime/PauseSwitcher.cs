using Global.Audio.Player.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace Global.System.Pauses.Runtime
{
    public class PauseSwitcher : IPause
    {
        public PauseSwitcher(
            IUpdateSpeedSetter updateSpeedSetter,
            IVolumeSetter volumeSetter,
            SoundState state)
        {
            _updateSpeedSetter = updateSpeedSetter;
            _volumeSetter = volumeSetter;
            _state = state;
        }

        private readonly IUpdateSpeedSetter _updateSpeedSetter;
        private readonly IVolumeSetter _volumeSetter;
        private readonly SoundState _state;

        public void Pause()
        {
            _updateSpeedSetter.Pause();

            if (_state.IsMuted == false)
                _volumeSetter.Mute();
        }

        public void Continue()
        {
            _updateSpeedSetter.Continue();

            if (_state.IsMuted == false)
                _volumeSetter.Unmute();
        }
    }
}