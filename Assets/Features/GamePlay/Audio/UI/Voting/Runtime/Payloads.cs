using System.Collections.Generic;
using Common.DataTypes.Network;
using GamePlay.Audio.Definitions;
using GamePlay.Network.Messaging.REST.Runtime;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Audio.UI.Voting.Runtime
{
    public class StartVoteEvent : IRagonEvent
    {
        public StartVoteEvent(Dictionary<string, AudioMetadata> entries)
        {
            _entries = entries;
        }

        public StartVoteEvent()
        {
            _entries = new Dictionary<string, AudioMetadata>();
        }

        private readonly Dictionary<string, AudioMetadata> _entries;

        public IReadOnlyDictionary<string, AudioMetadata> Entries => _entries;

        public void Serialize(RagonBuffer buffer)
        {
            var count = _entries.Values.Count;
            buffer.WriteInt(count, 0, 1000);

            foreach (var (_, metadata) in _entries)
                metadata.Serialize(buffer);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _entries.Clear();
            var count = buffer.ReadInt(0, 1000);

            for (var i = 0; i < count; i++)
            {
                var metadata = AudioMetadata.Deserialize(buffer);
                _entries.Add(metadata.Url, metadata);
            }
        }
    }

    public class EntryVoteEvent : NetworkEvent
    {
        public EntryVoteEvent()
        {
            Vote = new NetworkString();
            Construct(Vote);
        }

        public EntryVoteEvent(string vote)
        {
            Vote = new NetworkString(vote);
            Construct(Vote);
        }

        public readonly NetworkString Vote;
    }

    public class VoteEntriesUpdate : IRagonEvent
    {
        public VoteEntriesUpdate(Dictionary<string, int> votes)
        {
            _votes = votes;
        }

        public VoteEntriesUpdate()
        {
        }

        private static readonly NetworkIntCompressor _compressor = new(0, 1023);

        private readonly Dictionary<string, int> _votes;

        public IReadOnlyDictionary<string, int> Votes => _votes;

        public void Serialize(RagonBuffer buffer)
        {
            _compressor.Write(buffer, _votes.Count);

            foreach (var (url, amount) in _votes)
            {
                buffer.WriteString(url);
                _compressor.Write(buffer, amount);
            }
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var count = _compressor.Read(buffer);

            for (var i = 0; i < count; i++)
            {
                var url = buffer.ReadString();
                var amount = _compressor.Read(buffer);
                _votes.Add(url, amount);
            }
        }
    }

    public class EndVoteEvent : NetworkEvent
    {
        public EndVoteEvent(AudioMetadata winner)
        {
            _winner = winner;
        }

        public EndVoteEvent()
        {
        }

        private AudioMetadata _winner;

        public AudioMetadata Winner => _winner;

        protected override void OnSerialize(RagonBuffer buffer)
        {
            _winner.Serialize(buffer);
        }

        protected override void OnDeserialize(RagonBuffer buffer)
        {
            _winner = AudioMetadata.Deserialize(buffer);
        }
    }

    public class SuggestionRequest : NetworkEvent, IMessage
    {
        public SuggestionRequest(string suggestionUrl)
        {
            _id = new MessageId();
            _suggestionUrl = suggestionUrl;

            Construct(_id);
        }

        public SuggestionRequest()
        {
            _id = new MessageId();

            Construct(_id);
        }

        private readonly MessageId _id;
        private string _suggestionUrl;

        public IMessageId RequestId => _id;
        public string SuggestionUrl => _suggestionUrl;

        protected override void OnSerialize(RagonBuffer buffer)
        {
            buffer.WriteString(_suggestionUrl);
        }

        protected override void OnDeserialize(RagonBuffer buffer)
        {
            _suggestionUrl = buffer.ReadString();
        }
    }

    public class SuggestionResponse : NetworkEvent, IMessage
    {
        public SuggestionResponse()
        {
            _id = new MessageId();

            Construct(_id);
        }

        private readonly MessageId _id;

        public IMessageId RequestId => _id;
    }
}