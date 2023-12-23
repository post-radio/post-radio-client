using System.Collections.Generic;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using GamePlay.Network.Messaging.REST.Runtime.Abstract;

namespace GamePlay.Audio.UI.Voting.Runtime.Suggestion
{
    public class Suggestions : ISuggestions, IScopeSwitchListener
    {
        public Suggestions(
            IAudioBackend backend,
            IMessenger messenger,
            IMessageDistributor messageDistributor)
        {
            _backend = backend;
            _messenger = messenger;
            _messageDistributor = messageDistributor;
        }

        private readonly List<AudioMetadata> _suggestions = new();
        private readonly IAudioBackend _backend;
        private readonly IMessenger _messenger;
        private readonly IMessageDistributor _messageDistributor;

        private readonly CancellationTokenSource _cancellation = new();

        public void OnEnabled()
        {
            _messenger.AddRoute<SuggestionRequest, SuggestionResponse>(OnSuggestionReceived);
        }

        public void OnDisabled()
        {
            _cancellation.Cancel();
        }

        public void Clear()
        {
            _suggestions.Clear();
        }

        public IReadOnlyList<AudioMetadata> GetAll()
        {
            return new List<AudioMetadata>(_suggestions);
        }

        public async UniTask<bool> ProcessSuggestion(string url, CancellationToken cancellation)
        {
            var validationResult = await _backend.ValidateUrl(url, cancellation);

            if (validationResult.IsValid == false)
                return false;

            _messageDistributor.SendOwner<SuggestionRequest, SuggestionResponse>(new SuggestionRequest(url));

            return true;
        }
        
        private async UniTask OnSuggestionReceived(IResponseHandler<SuggestionRequest, SuggestionResponse> responseHandler)
        {
            var validationResult = await _backend.ValidateUrl(responseHandler.RequestPayload.SuggestionUrl, _cancellation.Token);

            if (validationResult.IsValid == false)
                return;

            _suggestions.Add(validationResult.Metadata);
        }
    }
}