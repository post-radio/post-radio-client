﻿using System;
using System.Threading;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Audio.Sync
{
    public class AudioSync :
        INetworkSceneEntityCreationListener,
        IAudioSync,
        IUpdatable,
        IScopeSwitchListener,
        INetworkAwakeListener
    {
        public AudioSync(
            IAudioTimeProvider timeProvider,
            IUpdater updater,
            IAudioPlayer player,
            IRoomProvider roomProvider,
            TimerSync timer)
        {
            _timeProvider = timeProvider;
            _updater = updater;
            _player = player;
            _roomProvider = roomProvider;
            _timer = timer;
        }

        private readonly IAudioTimeProvider _timeProvider;
        private readonly IUpdater _updater;
        private readonly IAudioPlayer _player;
        private readonly IRoomProvider _roomProvider;

        private readonly TimerSync _timer;
        private readonly CurrentAudioDataSync _current = new();
        private readonly NextAudioDataSync _next = new();

        private int _randomInt = 1;
        
        public event Action<AudioData> AudioChanged;

        public float Time => _timeProvider.CurrentTime;
        public AudioData CurrentAudioData => _current.Value;

        public void OnEnabled()
        {
            _current.Received += OnCurrentChanged;
            _next.Received += OnNextChanged;
        }

        public void OnDisabled()
        {
            _current.Received -= OnCurrentChanged;
            _next.Received -= OnNextChanged;

            if (_roomProvider.IsOwner == true)
                _updater.Remove(this);
        }

        public void OnNetworkAwake()
        {
            if (_roomProvider.IsOwner == true)
                _updater.Add(this);
        }

        public async UniTask OnSceneEntityCreation(ISceneEntityFactory factory)
        {
            await factory.Create(_timer, _next, _current);
        }

        public void SetNextAudio(AudioData audioData)
        {
            _next.SetAudio(audioData);
        }

        public async UniTask SetCurrentAudio(CancellationToken cancellation)
        {
            Debug.Log($"[Audio] 13.1 SetCurrentAudio start");

            _updater.Remove(this);
            _randomInt++;
            Debug.Log($"[Audio] 13.2 SetCurrentAudio set time: {_randomInt}");
            _timer.SetTime(0f, _randomInt);
            
            Debug.Log($"[Audio] 13.3 SetCurrentAudio wait until property changed");
            await UniTask.WaitUntil(() =>
            {
                _timer.MarkChanged(0f, _randomInt);  
                Debug.Log($"[Audio] 13.4 SetCurrentAudio result: " +
                          $"{_timer.TimeValue} - {Mathf.Approximately(_timer.TimeValue, 0f)} " +
                          $"&& {_timer.RandomIntValue == _randomInt} {_timer.RandomIntValue} == {_randomInt}");

                return Mathf.Approximately(_timer.TimeValue, 0f) && _timer.RandomIntValue == _randomInt;
            }, cancellationToken: cancellation);
            
            Debug.Log($"[Audio] 13.5 SetCurrentAudio wait until completed");
            _updater.Add(this);

            _current.SetAudio(_next.Value, _randomInt);
            Debug.Log($"[Audio] 13.5 SetCurrentAudio audio setted");
        }

        public void OnUpdate(float delta)
        {
            _timer.SetTime(_timeProvider.CurrentTime, _randomInt);
        }

        private void OnNextChanged()
        {
            _player.Preload(_next.Value, new CancellationTokenSource().Token).Forget();
        }
        
        private void OnCurrentChanged() 
        {
            SetCurrent().Forget();
        }

        private async UniTask SetCurrent()
        {
            if (_roomProvider.IsOwner == true)
                return;

            await UniTask.WaitUntil(() => _current.RandomInt.Value == _timer.RandomInt.Value);
            
            AudioChanged?.Invoke(_current.Value);
        }
    }
}