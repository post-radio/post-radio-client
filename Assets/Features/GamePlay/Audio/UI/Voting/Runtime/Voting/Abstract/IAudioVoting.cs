using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract
{
    public interface IAudioVoting
    {
        UniTask<StoredAudio> ForceRandomSelection();
        UniTask Fill();
        UniTask<StoredAudio> End();
    }
}