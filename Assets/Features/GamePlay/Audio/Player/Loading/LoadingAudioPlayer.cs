using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.Events;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Audio.Sync;
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
            TimerSync timer,
            IVolumeSetter volumeSetter)
        {
            _backend = backend;
            _source = source;
            _timer = timer;
            _volumeSetter = volumeSetter;
        }

        private readonly IAudioBackend _backend;
        private readonly IAudioPlayerSource _source;
        private readonly TimerSync _timer;
        private readonly IVolumeSetter _volumeSetter;

        private AudioClip _preloaded;
        private AudioClip _current;
        private StoredAudio _preloadedData;

        public void OnEnabled()
        {
            _volumeSetter.VolumeUpdated += OnVolumeUpdated;
            _source.SetVolume(_volumeSetter.Music);
        }

        public void OnDisabled()
        {
            _volumeSetter.VolumeUpdated -= OnVolumeUpdated;
        }

        public async UniTask Preload(StoredAudio audio, CancellationToken cancellation)
        {
            _preloaded = await _backend.LoadTrack(audio, cancellation);
            _preloadedData = audio;
        }

        public async UniTask Play(StoredAudio audio, CancellationToken cancellation)
        {
            AudioClip next;

            if (_preloaded != null && _preloadedData.Link == audio.Link)
            {
                next = _preloaded;
                _preloaded = null;
            }
            else
            {
                next = await _backend.LoadTrack(audio, cancellation);
            }

            await _source.Play(next, _timer.Time.Value);

            if (_current != null)
            {
                Object.Destroy(_current);
                _current = null;
            }

            _current = next;

            await Resources.UnloadUnusedAssets().ToUniTask();
            
            Msg.Publish(new SongChangeEvent(audio));
        }

        private void OnVolumeUpdated()
        {
            _source.SetVolume(_volumeSetter.Music);
        }
    }
}