using System;
using System.Collections.Generic;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Backend.Objects
{
    [Serializable]
    public class RandomTracksResponse
    {
        public RawMetadata[] Tracks { get; set; }
    }
    
    public class RandomTracksResult
    {
        public IReadOnlyList<AudioMetadata> Tracks { get; set; }
    }
}