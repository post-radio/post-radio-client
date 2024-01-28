using System.Threading;
using Common.Architecture.Scopes.Runtime.Callbacks;
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
            IGlobalVolume globalVolume)
        {
            _backend = backend;
            _source = source;
            _globalVolume = globalVolume;
        }

        private readonly IAudioBackend _backend;
        private readonly IAudioPlayerSource _source;
        private readonly IGlobalVolume _globalVolume;

        private AudioClip _preloaded;
        private AudioClip _current;
        private AudioData _preloadedData;

        public void OnEnabled()
        {
            _globalVolume.VolumeUpdated += OnGlobalVolumeUpdated;
            _source.SetVolume(_globalVolume.Music);
        }

        public void OnDisabled()
        {
            _globalVolume.VolumeUpdated -= OnGlobalVolumeUpdated;
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

        private void OnGlobalVolumeUpdated()
        {
            _source.SetVolume(_globalVolume.Music);
        }
    }
}