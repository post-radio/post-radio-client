using System.Collections.Generic;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract
{
    public interface IVotingSession
    {
        void Fill(Dictionary<string, AudioMetadata> entries);
        AudioMetadata End();
    }
}