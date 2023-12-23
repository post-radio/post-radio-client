using System;

namespace GamePlay.Audio.Backend.Objects
{
    [Serializable]
    public class RawMetadata
    {
        public string Url { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
    }
}