using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Events
{
    public class SongChangeEvent
    {
        public SongChangeEvent(StoredAudio audio)
        {
            Audio = audio;
        }
        
        public readonly StoredAudio Audio;
    }
}