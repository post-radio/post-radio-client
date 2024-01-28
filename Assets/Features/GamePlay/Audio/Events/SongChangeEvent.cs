using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Events
{
    public class SongChangeEvent
    {
        public SongChangeEvent(AudioData audioData)
        {
            AudioData = audioData;
        }
        
        public readonly AudioData AudioData;
    }
}