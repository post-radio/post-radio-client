namespace Global.Audio.Player.Runtime
{
    public interface IVolumeSetter
    {
        void Mute();
        void Unmute();

        void SaveVolume();
        void SetVolume(float music, float sound);
    }
}