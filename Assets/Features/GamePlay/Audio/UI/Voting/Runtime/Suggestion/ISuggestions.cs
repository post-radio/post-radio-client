using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.Runtime.Suggestion
{
    public interface ISuggestions
    {
        UniTask<bool> ProcessSuggestion(string url, CancellationToken cancellation);
        void Clear();
        IReadOnlyList<AudioMetadata> GetAll();
    }
}