namespace GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract
{
    public interface ISuggestionInterceptor
    {
        void OnRequest(string url);
        void OnCloseClicked();
    }
}