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
        UniTask<StoredAudio> GetAudioLink(AudioMetadata metadata);
        UniTask<RandomTracksResult> GetRandomTracks();
        UniTask<AudioClip> LoadTrack(StoredAudio audio);
    }
}