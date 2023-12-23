using System.Threading;
using Cysharp.Threading.Tasks;

namespace GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract
{
    public interface ISuggestionView
    {
        void Construct(ISuggestionInterceptor interceptor);
        void Open();
        void Close();
        UniTask OnSuccess(CancellationToken cancellation);
        UniTask OnFail(CancellationToken cancellation);
    }
}