using System.Threading;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using GamePlay.Audio.Definitions;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Audio.Sync;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using GamePlay.Network.Room.Lifecycle.Runtime;
using UnityEngine;

namespace GamePlay.Audio.Controller
{
    public class AudioController : IAudioController, IScopeLoadAsyncListener, IScopeDisableListener
    {
        public AudioController(
            IAudioSync sync,
            IAudioTimeProvider timeProvider,
            IRoomProvider roomProvider,
            IAudioVoting voting,
            IAudioPlayer player,
            AudioOptions options)
        {
            _sync = sync;
            _timeProvider = timeProvider;
            _roomProvider = roomProvider;
            _voting = voting;
            _player = player;
            _options = options;
        }

        private readonly IAudioSync _sync;
        private readonly IAudioTimeProvider _timeProvider;
        private readonly IRoomProvider _roomProvider;
        private readonly IAudioVoting _voting;
        private readonly IAudioPlayer _player;
        private readonly AudioOptions _options;

        private CancellationTokenSource _cancellation;

        public async UniTask OnLoadedAsync()
        {
            _cancellation = new CancellationTokenSource();
            _sync.AudioChanged += OnAudioChanged;

            if (_roomProvider.IsOwner == true)
            {
                var audio = await _voting.ForceRandomSelection();
                _sync.SetNextAudio(audio);
                await _voting.Fill();

                RunLoop(audio).Forget();
            }
            else
            {
                var audio = _sync.CurrentAudioData ?? await WaitNextAudio();
                RunLoop(audio).Forget();
            }
        }

        public void OnDisabled()
        {
            _cancellation.Cancel();
            _sync.AudioChanged -= OnAudioChanged;
        }

        private async UniTask RunLoop(AudioData nextAudio)
        {
            while (true)
            {
                if (_roomProvider.IsOwner == true)
                    nextAudio = await HandleOwnerLoop(nextAudio);
                else
                    nextAudio = await HandleRemoteLoop(nextAudio);
            }
        }

        private async UniTask<AudioData> HandleOwnerLoop(AudioData nextAudio)
        {
            Debug.Log($"[Audio] 0 HandleOwnerLoop start");
            var playTask = await _player.Play(nextAudio, 0f, _cancellation.Token);
            Debug.Log($"[Audio] 13 Play completed, set current audio");
            await _sync.SetCurrentAudio(_cancellation.Token);
            Debug.Log($"[Audio] 14 Wait vote");
            await WaitForVoteEnd(_cancellation.Token);
            Debug.Log($"[Audio] 18 run voting end");

            nextAudio = await _voting.End();
            Debug.Log($"[Audio] 18 Fill vote");
            await _voting.Fill();
            Debug.Log($"[Audio] 19 set next audio");
            _sync.SetNextAudio(nextAudio);
            Debug.Log($"[Audio] 20 wait audio task end");
            await playTask;

            return nextAudio;
        }

        private async UniTask<AudioData> HandleRemoteLoop(AudioData nextAudio)
        {
            var time = _sync.Time;
            var playTask = await _player.Play(nextAudio, time, _cancellation.Token);
            await playTask;
            nextAudio = await WaitNextAudio();

            return nextAudio;
        }

        private async UniTask<AudioData> WaitNextAudio()
        {
            var completion = new UniTaskCompletionSource<AudioData>();

            _sync.AudioChanged += OnAudioChangedWhileWait;
            _roomProvider.BecameOwner += OnOwnershipGranted;
            var audio = await completion.Task;
            _sync.AudioChanged -= OnAudioChangedWhileWait;
            _roomProvider.BecameOwner -= OnOwnershipGranted;

            return audio;

            void OnAudioChangedWhileWait(AudioData nextAudio)
            {
                completion.TrySetResult(nextAudio);
            }

            void OnOwnershipGranted()
            {
                SelectAudioAsOwner().Forget();
            }

            async UniTask SelectAudioAsOwner()
            {
                var nextAudio = await _voting.ForceRandomSelection();
                completion.TrySetResult(nextAudio);
            }
        }

        private async UniTask WaitForVoteEnd(CancellationToken cancellation)
        {
            Debug.Log($"[Wait] 15 WaitForVoteEnd start");

            while (_timeProvider.Duration - _timeProvider.CurrentTime > _options.Vote.VoteStartOffset)
            {
                Debug.Log($"[Wait] 16 WaitForVoteEnd in progress: " +
                          $"{_timeProvider.Duration} - {_timeProvider.CurrentTime} ({_timeProvider.Duration - _timeProvider.CurrentTime}) > {_options.Vote.VoteStartOffset}");

                await UniTask.Yield(cancellation);
            }
            
            Debug.Log($"[Wait] 17 WaitForVoteEnd end");
        }

        private void OnAudioChanged(AudioData audio)
        {
            if (_roomProvider.IsOwner == true)
                return;

            _cancellation.Cancel();
            RunLoop(audio).Forget();
        }
    }
}