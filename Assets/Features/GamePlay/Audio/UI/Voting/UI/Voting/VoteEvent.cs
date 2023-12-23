using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.UI.Voting
{
    public readonly struct VoteEvent
    {
        public VoteEvent(AudioMetadata metadata)
        {
            Metadata = metadata;
        }
        
        public readonly AudioMetadata Metadata;
    }
}