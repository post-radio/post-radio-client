using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract;
using GamePlay.Audio.UI.Voting.UI.Voting.Abstract;
using Global.UI.Nova.Components;
using NovaSamples.UIControls;

namespace GamePlay.Audio.UI.Voting.Runtime.Suggestion
{
    public class SuggestionController : ISuggestionInterceptor, IScopeSwitchListener
    {
        public SuggestionController(IVotingUIScheme scheme, ISuggestions suggestions)
        {
            _suggestions = suggestions;
            _view = scheme.SuggestionView;
            _button = scheme.SuggestionButton;
        }

        private readonly ISuggestionView _view;
        private readonly ISuggestions _suggestions;
        private readonly UIButton _button;
        private readonly CancellationTokenSource _cancellation = new();
        
        private bool _isActive;

        public void OnEnabled()
        {
            _view.Construct(this);
            _view.Close();
            _button.Clicked += OnClicked;
        }

        public void OnDisabled()
        {
            _button.Clicked -= OnClicked;
            _cancellation.Cancel();
        }

        private void OnClicked()
        {
            if (_isActive == true)
                _view.Close();
            else
                _view.Open();

            _isActive = !_isActive;
        }

        public void OnRequest(string url)
        {
            ProcessRequest(url).Forget();
        }

        public void OnCloseClicked()
        {
            _isActive = false;
            _view.Close();
        }

        private async UniTask ProcessRequest(string url)
        {
            _button.enabled = false;
            var result = await _suggestions.ProcessSuggestion(url, _cancellation.Token);

            if (result == true)
                await _view.OnSuccess(_cancellation.Token);
            else
                await _view.OnFail(_cancellation.Token);
            
            _button.enabled = true;
        }
    }
}