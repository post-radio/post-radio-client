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
        
        public static RandomTracksResult ToResult(IEnumerable<RawMetadata> tracks)
        {
            var results = new List<AudioMetadata>();

            foreach (var rawMetadata in tracks)
                results.Add(new AudioMetadata(rawMetadata.Url, rawMetadata.Author, rawMetadata.Name));

            return new RandomTracksResult
            {
                Tracks = results
            };
        }
    }
}