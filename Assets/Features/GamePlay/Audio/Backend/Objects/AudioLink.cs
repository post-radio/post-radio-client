using System;

namespace GamePlay.Audio.Backend.Objects
{
    [Serializable]
    public class AudioLinkRequest
    {
        public string AudioUrl { get; set; }
    }
    
    [Serializable]
    public class AudioLinkResponse
    {
        public string AudioUrl { get; set; }
    }
    
    public class AudioLinkResult
    {
        public string AudioLink { get; set; }
    }
}