using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract
{
    public interface IAudioVoting
    {
        UniTask<AudioData> ForceRandomSelection();
        UniTask Fill();
        UniTask<AudioData> End();
    }
}