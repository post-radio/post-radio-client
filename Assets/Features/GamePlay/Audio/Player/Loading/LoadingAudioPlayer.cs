using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.Events;
using GamePlay.Audio.Player.Abstract;
using Global.Audio.Player.Runtime;
using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GamePlay.Audio.Player.Loading
{
    public class LoadingAudioPlayer : IAudioPlayer, IScopeSwitchListener
    {
        public LoadingAudioPlayer(
            IAudioBackend backend,
            IAudioPlayerSource source,
            IVolumeSetter volumeSetter)
        {
            _backend = backend;
            _source = source;
            _volumeSetter = volumeSetter;
        }

        private readonly IAudioBackend _backend;
        private readonly IAudioPlayerSource _source;
        private readonly IVolumeSetter _volumeSetter;

        private AudioClip _preloaded;
        private AudioClip _current;
        private AudioData _preloadedData;

        public void OnEnabled()
        {
            _volumeSetter.VolumeUpdated += OnVolumeUpdated;
            _source.SetVolume(_volumeSetter.Music);
        }

        public void OnDisabled()
        {
            _volumeSetter.VolumeUpdated -= OnVolumeUpdated;
        }

        public async UniTask Preload(AudioData audioData, CancellationToken cancellation)
        {
            _preloaded = await _backend.LoadTrack(audioData, cancellation);
            _preloadedData = audioData;
        }

        public async UniTask<UniTask> Play(AudioData audioData, float time, CancellationToken cancellation)
        {
            await Resources.UnloadUnusedAssets().ToUniTask(cancellationToken: cancellation);

            AudioClip next;

            if (_preloaded != null && _preloadedData.Link == audioData.Link)
            {
                next = _preloaded;
                _preloaded = null;
            }
            else
            {
                next = await _backend.LoadTrack(audioData, cancellation);
            }

            var playTask = await _source.Play(next, time, cancellation);

            if (_current != null)
            {
                Object.Destroy(_current);
                _current = null;
            }

            _current = next;

            Msg.Publish(new SongChangeEvent(audioData));

            return playTask;
        }

        private void OnVolumeUpdated()
        {
            _source.SetVolume(_volumeSetter.Music);
        }
    }
}