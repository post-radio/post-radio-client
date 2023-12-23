using System;
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
using UnityEngine.Networking;
using Object = UnityEngine.Object;

namespace GamePlay.Audio.Player.Loading
{
    public class LoadingAudioPlayer : IAudioPlayer, IScopeSwitchListener
    {
        public LoadingAudioPlayer(
            IAudioBackend backend,
            IBackendRoutes routes,
            IAudioPlayerSource source,
            TimerSync timer,
            IVolumeSetter volumeSetter)
        {
            _backend = backend;
            _routes = routes;
            _source = source;
            _timer = timer;
            _volumeSetter = volumeSetter;
        }

        private readonly IAudioBackend _backend;
        private readonly IBackendRoutes _routes;
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

        public async UniTask Preload(StoredAudio audio)
        {
            _preloaded = await LoadAudio(audio);
            _preloadedData = audio;
        }

        public async UniTask Play(StoredAudio audio)
        {
            AudioClip next;

            if (_preloaded != null && _preloadedData.Link == audio.Link)
            {
                next = _preloaded;
                _preloaded = null;
            }
            else
            {
                next = await LoadAudio(audio);
            }

            Debug.Log($"Play loaded audio: {_timer.Time.Value}");

            await _source.Play(next, _timer.Time.Value);

            if (_current != null)
            {
                Object.Destroy(_current);
                _current = null;
            }

            _current = next;

            await Resources.UnloadUnusedAssets().ToUniTask();
            
            Msg.Publish(new SongChangeEvent(audio));
            
            Debug.Log($"On audio play completed");
        }

        private async UniTask<AudioClip> LoadAudio(StoredAudio audio)
        {
            var uri = _routes.AudioStorage(audio.Link);
            var audioType = AudioType.MPEG;
            using var downloadHandlerAudioClip = new DownloadHandlerAudioClip(uri, audioType);
            using var request = new UnityWebRequest(uri, "GET", downloadHandlerAudioClip, null);
            var response = await request.SendWebRequest().ToUniTask();

            if (response.result
                is UnityWebRequest.Result.ConnectionError
                or UnityWebRequest.Result.ProtocolError
                or UnityWebRequest.Result.DataProcessingError)
                throw new Exception();

            return downloadHandlerAudioClip.audioClip;
        }

        private void OnVolumeUpdated()
        {
            _source.SetVolume(_volumeSetter.Music);
        }
    }
}