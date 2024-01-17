using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Tools.Backend;
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
            return await Transactions.Run(Handle);

            async UniTask<StoredAudio> Handle(bool isRetry, CancellationToken cancellation)
            {
                var random = await _backend.GetRandomTracks(cancellation);
                var metadata = random.Tracks.First();
                var audio = await _backend.GetAudioLink(metadata, cancellation);

                return audio;
            }
        }

        public async UniTask Fill()
        {
            var entries = new List<AudioMetadata>();

            var suggestions = _suggestions.GetAll();
            _suggestions.Clear();
            entries.AddRange(suggestions);

            var cancellation = new CancellationTokenSource();
            var random = await _backend.GetRandomTracks(cancellation.Token);
            entries.AddRange(random.Tracks);
            var entriesDictionary = new Dictionary<string, AudioMetadata>();

            foreach (var entry in entries)
                entriesDictionary.TryAdd(entry.Url, entry);

            _votingSession.Fill(entriesDictionary);
        }

        public async UniTask<StoredAudio> End()
        {
            var winnerMetadata = _votingSession.End();
            StoredAudio winner = null;
            var isSuccess = false;
            var cancellation = new CancellationTokenSource();

            while (isSuccess == false)
            {
                try
                {
                    winner = await _backend.GetAudioLink(winnerMetadata, cancellation.Token);
                    isSuccess = true;
                }
                catch (Exception exception)
                {
                    isSuccess = false;
                    Debug.LogError($"Exception during audio link request: {exception.Message}");
                    await UniTask.Delay(3f);
                    var random = await _backend.GetRandomTracks(cancellation.Token);
                    var metadata = random.Tracks.First();
                    winnerMetadata = metadata;
                }
            }

            return winner;
        }
    }
}