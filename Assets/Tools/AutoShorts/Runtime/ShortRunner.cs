﻿using System;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Backend;
using GamePlay.Audio.Definitions;
using Tools.AutoShorts.Runtime.SlideShow;
using UnityEngine;
using UnityEngine.Networking;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Recorder;
#endif

namespace Tools.AutoShorts.Runtime
{
    public class ShortRunner : IScopeLoadAsyncListener
    {
        public ShortRunner(
            IAudioBackend backend, 
            IBackendRoutes routes,
            IShortCreator creator,
            ISlideShow slideShow,
            IShortsPlayer player)
        {
            _backend = backend;
            _routes = routes;
            _creator = creator;
            _slideShow = slideShow;
            _player = player;
        }

        private readonly IAudioBackend _backend;
        private readonly IBackendRoutes _routes;
        private readonly IShortCreator _creator;
        private readonly ISlideShow _slideShow;
        private readonly IShortsPlayer _player;

        public async UniTask OnLoadedAsync()
        {
            var audioOptions = _creator.AudioOptions;
            var validation = await _backend.ValidateUrl(audioOptions.AudioURL, new CancellationToken());
            var storedAudio = await _backend.GetAudioLink(validation.Metadata);
            var clip = await LoadAudio(storedAudio);

            _player.Play(clip, audioOptions.StartOffset);
            _slideShow.Play(_creator.SlideShowOptions, _creator.Slides);

            #if UNITY_EDITOR
            var recorder = (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
            recorder.StartRecording();
            await UniTask.Delay(audioOptions.Length);
            recorder.StopRecording();
            #endif
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
    }
}