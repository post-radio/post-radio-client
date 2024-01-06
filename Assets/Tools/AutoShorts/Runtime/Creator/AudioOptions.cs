namespace Tools.AutoShorts.Runtime
{
    public class AudioOptions
    {
        public AudioOptions(string audioURL, float startOffset, float length)
        {
            AudioURL = audioURL;
            StartOffset = startOffset;
            Length = length;
        }
        
        public string AudioURL { get; }
        public float StartOffset { get; }
        public float Length { get; }
    }
}