using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Network.Room.Entities.Factory;
using GamePlay.Network.Room.EventLoops.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Audio.Sync
{
    public class AudioSetter :
        INetworkSceneEntityCreationListener,
        IAudioSetter,
        IUpdatable,
        IScopeSwitchListener,
        INetworkAwakeListener
    {
        public AudioSetter(
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

        public StoredAudio Current => _current.Value;

        public float Time => _timer.Time.Value;

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

        public void SetNextAudio(StoredAudio audio)
        {
            _next.SetAudio(audio);
        }

        public async UniTask PlayFirstAudio(StoredAudio audio)
        {
            if (_roomProvider.IsOwner == false)
                return;

            _updater.Remove(this);
            _randomInt++;

            await _player.Play(audio);
            _updater.Add(this);

            _current.SetAudio(audio, _randomInt);
        }

        public async UniTask PlayNextAudio()
        {
            if (_roomProvider.IsOwner == false)
                return;

            _updater.Remove(this);
            _timeProvider.Reset();
            _randomInt++;
            _timer.SetTime(0f, _randomInt);
            
            await UniTask.WaitUntil(() =>
            {
                _timer.MarkChanged(0f, _randomInt);
                return Mathf.Approximately(_timer.TimeValue, 0f) && _timer.RandomIntValue == _randomInt;
            });

            await _player.Play(_next.Value);
            _updater.Add(this);

            _current.SetAudio(_next.Value, _randomInt);
        }

        public void OnUpdate(float delta)
        {
            _timer.SetTime(_timeProvider.CurrentTime, _randomInt);
        }

        private void OnCurrentChanged()
        {
            SetCurrent().Forget();
        }

        private void OnNextChanged()
        {
            _player.Preload(_next.Value).Forget();
        }

        private async UniTask SetCurrent()
        {
            if (_roomProvider.IsOwner == true)
                return;

            _timer.SetTime(0f, _randomInt);

            await UniTask.WaitUntil(() => _current.RandomInt.Value == _timer.RandomInt.Value);

            await _player.Play(_current.Value);
        }
    }
}