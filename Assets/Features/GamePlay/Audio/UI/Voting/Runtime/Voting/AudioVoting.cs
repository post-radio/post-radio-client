using System.Collections.Generic;
using System.Linq;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.UI.Voting.Runtime.Suggestion;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using Global.UI.Nova.Components;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting
{
    public class AudioVoting : IAudioVoting, IScopeSwitchListener
    {
        public AudioVoting(
            ISuggestions suggestions,
            IAudioBackend backend,
            IVotingSession votingSession,
            IVotingUIScheme scheme)
        {
            _suggestions = suggestions;
            _backend = backend;
            _votingSession = votingSession;
            _button = scheme.VoteButton;
            _view = scheme.VotingView;
        }

        private readonly ISuggestions _suggestions;
        private readonly IAudioBackend _backend;
        private readonly IVotingSession _votingSession;
        private readonly UIButton _button;
        private readonly IVotingView _view;

        private bool _isActive;

        public void OnEnabled()
        {
            _view.Close();
            _button.Clicked += OnClicked;
        }

        public void OnDisabled()
        {
            _button.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            if (_isActive == true)
                _view.Close();
            else
                _view.Open();

            _isActive = !_isActive;
        }

        public async UniTask<StoredAudio> ForceRandomSelection()
        {
            var random = await _backend.GetRandomTracks();
            var metadata = random.Tracks.First();
            var audio = await _backend.GetAudioLink(metadata);
            return audio;
        }

        public async UniTask Fill()
        {
            var entries = new List<AudioMetadata>();

            var suggestions = _suggestions.GetAll();
            _suggestions.Clear();
            entries.AddRange(suggestions);

            var random = await _backend.GetRandomTracks();
            entries.AddRange(random.Tracks);

            var entriesDictionary = entries.ToDictionary(t => t.Url);

            _votingSession.Fill(entriesDictionary);
        }

        public async UniTask<StoredAudio> End()
        {
            var winnerMetadata = _votingSession.End();
            var winner = await _backend.GetAudioLink(winnerMetadata);

            return winner;
        }
    }
}