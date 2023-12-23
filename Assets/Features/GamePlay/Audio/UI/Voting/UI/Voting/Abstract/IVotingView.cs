using System;
using System.Collections.Generic;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.UI.Voting.Abstract
{
    public interface IVotingView
    {
        event Action<AudioMetadata> Selected;
        void Fill(IReadOnlyDictionary<string, AudioMetadata> entries);
        void End(AudioMetadata winner);
        void UpdateVotes(IReadOnlyDictionary<string, int> entriesVotes);
        void Open();
        void Close();
    }
}