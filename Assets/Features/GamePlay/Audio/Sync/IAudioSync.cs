using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;

namespace GamePlay.Audio.Sync
{
    public interface IAudioSync
    {
        event Action<AudioData> AudioChanged;
        
        float Time { get; }
        AudioData CurrentAudioData { get; }
        
        void  SetNextAudio(AudioData audioData);
        UniTask SetCurrentAudio(CancellationToken cancellation);
    }
}