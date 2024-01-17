using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Sync
{
    public interface IAudioSetter
    {
        StoredAudio Current { get; }
        float Time { get; }

        void SetNextAudio(StoredAudio audio);
        UniTask PlayFirstAudio(StoredAudio audio, CancellationToken cancellation);
        UniTask PlayNextAudio(CancellationToken cancellation);
    }
}