using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using GamePlay.Network.Messaging.Events.Runtime;
using Ragon.Client;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting
{
    public class VotingSession : IVotingSession, IScopeSwitchListener
    {
        public VotingSession(
            IVotingView votingView,
            INetworkEvents events,
            INetworkEventsDistributor eventsDistributor)
        {
            _votingView = votingView;
            _events = events;
            _eventsDistributor = eventsDistributor;
        }

        private readonly IVotingView _votingView;
        private readonly INetworkEvents _events;
        private readonly INetworkEventsDistributor _eventsDistributor;

        private readonly Dictionary<string, int> _votes = new();
        private readonly Dictionary<RagonPlayer, string> _playersVotes = new();

        private IDisposable _voteListener;
        private CancellationTokenSource _cancellation;
        private IReadOnlyDictionary<string, AudioMetadata> _entries;

        public void OnEnabled()
        {
            _events.AddRoute<VoteEntriesUpdate>(OnEntriesUpdate);
            _events.AddRoute<StartVoteEvent>(OnVoteStartRequest);
            _events.AddRoute<EntryVoteEvent>(OnEntryVoted);
            _events.AddRoute<EndVoteEvent>(OnVoteEndRequest);

            _votingView.Selected += OnEntrySelected;
            _cancellation = new CancellationTokenSource();
        }

        public void OnDisabled()
        {
            _votingView.Selected -= OnEntrySelected;

            _voteListener.Dispose();
            _cancellation.Cancel();
        }

        public void Fill(Dictionary<string, AudioMetadata> entries)
        {
            _entries = entries;
            _votes.Clear();
            _playersVotes.Clear();
            _eventsDistributor.SendAll(new StartVoteEvent(entries));
        }

        public AudioMetadata End()
        {
            var winner = CalculateWinner(_votes, _entries);
            _eventsDistributor.SendAll(new EndVoteEvent(winner));
            return winner;
        }

        private void OnEntrySelected(AudioMetadata audio)
        {
            var payload = new EntryVoteEvent(audio.Url);
            _eventsDistributor.SendOwner(payload);
        }

        private void OnEntryVoted(RagonPlayer player, EntryVoteEvent payload)
        {
            var currentVote = payload.Vote.Value;

            if (_playersVotes.TryGetValue(player, out var previousVote))
                _votes[previousVote] -= 1;

            _votes.TryAdd(currentVote, 0);
            _votes[currentVote] += 1;
            
            if (_playersVotes.TryAdd(player, currentVote) == false)
                _playersVotes[player] = currentVote;
            
            var responsePayload = new VoteEntriesUpdate(_votes);
            _eventsDistributor.SendAll(responsePayload);
        }

        private void OnEntriesUpdate(RagonPlayer player, VoteEntriesUpdate update)
        {
            _votingView.UpdateVotes(update.Votes);
        }

        private void OnVoteStartRequest(RagonPlayer player, StartVoteEvent payload)
        {
            _votingView.Fill(payload.Entries);
        }

        private void OnVoteEndRequest(RagonPlayer player, EndVoteEvent payload)
        {
            _votingView.End(payload.Winner);
        }

        private AudioMetadata CalculateWinner(
            IReadOnlyDictionary<string, int> votes,
            IReadOnlyDictionary<string, AudioMetadata> entries)
        {
            if (votes.Count == 0)
                return entries.Values.First();

            var winnerUrl = votes.First().Key;
            var winnerVotesCount = 0;

            foreach (var (url, votesCount) in votes)
            {
                if (votesCount < winnerVotesCount)
                    continue;

                winnerUrl = url;
                winnerVotesCount = votesCount;
            }

            var winner = entries[winnerUrl];

            return winner;
        }
    }
}