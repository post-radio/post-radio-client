using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Common;
using GamePlay.Audio.Player.Abstract;
using GamePlay.Audio.Sync;
using GamePlay.Audio.UI.Voting.Runtime.Voting.Abstract;
using Global.Network.Handlers.ClientHandler.Runtime;
using UnityEngine;

namespace GamePlay.Audio.Controller
{
    public class AudioController : IAudioController, IScopeLoadAsyncListener, IScopeDisableListener
    {
        public AudioController(
            IAudioSetter setter,
            IAudioTimeProvider timeProvider,
            IRoomProvider roomProvider,
            IAudioVoting voting,
            AudioOptions options)
        {
            _setter = setter;
            _timeProvider = timeProvider;
            _roomProvider = roomProvider;
            _voting = voting;
            _options = options;
        }

        private readonly IAudioSetter _setter;
        private readonly IAudioTimeProvider _timeProvider;
        private readonly IRoomProvider _roomProvider;
        private readonly IAudioVoting _voting;
        private readonly AudioOptions _options;

        private CancellationTokenSource _cancellation;

        public async UniTask OnLoadedAsync()
        {
            if (_roomProvider.IsOwner == false)
                return;

            _cancellation = new CancellationTokenSource();
            var audio = await _voting.ForceRandomSelection();
            await _setter.PlayFirstAudio(audio);

            await Loop();
        }

        public void OnDisabled()
        {
            _cancellation.Cancel();
        }

        private async UniTask Loop()
        {
            while (true)
            {
                await _voting.Fill();
                await WaitForVoteEnd(_cancellation.Token);
                var audio = await _voting.End();
                await WaitAudioEnd(_cancellation.Token);
                _setter.SetNextAudio(audio);
                await _setter.PlayNextAudio();
            }
        }

        private async UniTask WaitForVoteEnd(CancellationToken cancellation)
        {
            while (_timeProvider.Duration - _timeProvider.CurrentTime > _options.Vote.VoteStartOffset)
            {
                Debug.Log($"WaitForVoteEnd: {_timeProvider.Duration} - {_timeProvider.CurrentTime}");
                await UniTask.Yield(cancellation);
            }
        }

        private async UniTask WaitAudioEnd(CancellationToken cancellation)
        {
            while (_timeProvider.CurrentTime < _timeProvider.Duration - 0.5f && _timeProvider.ContainsClip == true)
            {
                Debug.Log($"WaitAudioEnd: {_timeProvider.CurrentTime} > {_timeProvider.Duration - 0.5f} {_timeProvider.ContainsClip}");

                await UniTask.Yield(cancellation);
            }
        }
    }
}