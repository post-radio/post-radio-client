using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend.Objects;
using GamePlay.Audio.Definitions;
using UnityEngine;

namespace GamePlay.Audio.Backend
{
    public interface IAudioBackend
    {
        UniTask<UrlValidationResult> ValidateUrl(string audioUrl, CancellationToken cancellation);
        UniTask<AudioData> GetAudioLink(AudioMetadata metadata, CancellationToken cancellation);
        UniTask<RandomTracksResult> GetRandomTracks(CancellationToken cancellation);
        UniTask<AudioClip> LoadTrack(AudioData audioData, CancellationToken cancellation);
    }
}