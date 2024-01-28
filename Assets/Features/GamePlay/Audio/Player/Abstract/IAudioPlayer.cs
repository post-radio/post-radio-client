using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Player.Abstract
{
    public interface IAudioPlayer
    {
        UniTask Preload(AudioData audioDataMetadata, CancellationToken cancellation);
        UniTask<UniTask> Play(AudioData audioDataMetadata, float time, CancellationToken cancellation);
    }
}