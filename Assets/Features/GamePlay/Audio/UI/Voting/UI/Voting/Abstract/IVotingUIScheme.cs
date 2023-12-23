using GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract;
using Global.UI.Nova.Components;

namespace GamePlay.Audio.UI.Voting.UI.Voting.Abstract
{
    public interface IVotingUIScheme
    {
        IVotingView VotingView { get; }
        ISuggestionView SuggestionView { get; }
        UIButton SuggestionButton { get; }
        UIButton VoteButton { get; }
    }
}