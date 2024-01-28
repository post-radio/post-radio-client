using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.UI.Voting.Runtime.Suggestion;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using Global.Backend.Transactions;
using Global.UI.Nova.Components;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting
{
    public class AudioVoting : IAudioVoting, IScopeSwitchListener
    {
        public AudioVoting(
            ITransactionRunner transactionRunner,
            ISuggestions suggestions,
            IAudioBackend backend,
            IVotingSession votingSession,
            IVotingUIScheme scheme)
        {
            _transactionRunner = transactionRunner;
            _suggestions = suggestions;
            _backend = backend;
            _votingSession = votingSession;
            _button = scheme.VoteButton;
            _view = scheme.VotingView;
        }

        private readonly ITransactionRunner _transactionRunner;
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

        public async UniTask<AudioData> ForceRandomSelection()
        {
            return await _transactionRunner.Run(Handle);

            async UniTask<AudioData> Handle(bool isRetry, CancellationToken cancellation)
            {
                var random = await _backend.GetRandomTracks(cancellation);
                var metadata = random.Tracks.Last();
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

            await _transactionRunner.Run(GetRandomTracks);

            var entriesDictionary = new Dictionary<string, AudioMetadata>();

            foreach (var entry in entries)
                entriesDictionary.TryAdd(entry.Url, entry);

            _votingSession.Fill(entriesDictionary);
            
            return;

            async UniTask GetRandomTracks(bool isRetry, CancellationToken cancellation)
            {
                var random = await _backend.GetRandomTracks(cancellation);
                entries.AddRange(random.Tracks);
            }
        }

        public async UniTask<AudioData> End()
        {
            if (_votingSession.IsFilled == false)
                await Fill();
            
            var winnerMetadata = _votingSession.End();
            AudioData winner = null;

            await _transactionRunner.Run(GetWinner);

            return winner;

            async UniTask GetWinner(bool isRetry, CancellationToken cancellation)
            {
                if (isRetry == true)
                {
                    var random = await _backend.GetRandomTracks(cancellation);
                    var metadata = random.Tracks.First();
                    winnerMetadata = metadata;
                }
                
                winner = await _backend.GetAudioLink(winnerMetadata, cancellation);
            }
        }
    }
}