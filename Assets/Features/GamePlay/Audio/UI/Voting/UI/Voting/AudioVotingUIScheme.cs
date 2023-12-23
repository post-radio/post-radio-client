using GamePlay.Audio.UI.Voting.UI.Suggestion;
using GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using Global.UI.Nova.Components;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.UI.Voting
{
    [DisallowMultipleComponent]
    public class AudioVotingUIScheme : MonoBehaviour, IVotingUIScheme
    {
        [SerializeField] private VotingView _votingView;
        [SerializeField] private SuggestionView _suggestionView;
        [SerializeField] private UIButton _suggestionButton;
        [SerializeField] private UIButton _voteButton;

        public IVotingView VotingView => _votingView;
        public ISuggestionView SuggestionView => _suggestionView;
        public UIButton SuggestionButton => _suggestionButton;
        public UIButton VoteButton => _voteButton;
    }
}