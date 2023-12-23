using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Player.Abstract
{
    public interface IAudioPlayer
    {
        UniTask Preload(StoredAudio audioMetadata);
        UniTask Play(StoredAudio audioMetadata);
    }
}