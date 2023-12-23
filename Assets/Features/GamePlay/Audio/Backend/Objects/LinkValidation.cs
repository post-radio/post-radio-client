using System;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Backend.Objects
{
    [Serializable]
    public class UrlValidationRequest
    {
        public string AudioUrl { get; set; }
    }

    [Serializable]
    public class UrlValidationResponse
    {
        public bool IsValid { get; set; }
        public RawMetadata Metadata { get; set; }
    }
    
    public class UrlValidationResult
    {
        public bool IsValid { get; set; }
        public AudioMetadata Metadata { get; set; }
    }
}