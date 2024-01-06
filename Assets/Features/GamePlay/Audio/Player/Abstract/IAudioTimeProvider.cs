namespace GamePlay.Audio.Player.Abstract
{
    public interface IAudioTimeProvider
    {
        float CurrentTime { get; }
        float Duration { get; }
        bool ContainsClip { get; }

        void Reset();
    }
}