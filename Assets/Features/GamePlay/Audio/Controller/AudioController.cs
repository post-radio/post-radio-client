using System;
using System.Threading;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Common.Tools.Backend;
using Cysharp.Threading.Tasks;
using Features.Global.Services.Publisher.Abstract.Callbacks;
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
            IJsErrorCallback errorCallback,
            AudioOptions options)
        {
            _setter = setter;
            _timeProvider = timeProvider;
            _roomProvider = roomProvider;
            _voting = voting;
            _errorCallback = errorCallback;
            _options = options;
        }

        private readonly IAudioSetter _setter;
        private readonly IAudioTimeProvider _timeProvider;
        private readonly IRoomProvider _roomProvider;
        private readonly IAudioVoting _voting;
        private readonly IJsErrorCallback _errorCallback;
        private readonly AudioOptions _options;

        private CancellationTokenSource _cancellation;

        public async UniTask OnLoadedAsync()
        {
            if (_roomProvider.IsOwner == false)
                return;

            _cancellation = new CancellationTokenSource();

            await Transactions.Run(Handle);

            await Loop();
            
            return;

            async UniTask Handle(bool isRetry)
            {
                var audio = await _voting.ForceRandomSelection();
                await _setter.PlayFirstAudio(audio);
            }
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
                await Transactions.Run(Handle);

                continue;

                async UniTask Handle(bool isRetry)
                {
                    if (isRetry == true)
                        audio = await _voting.ForceRandomSelection();

                    _errorCallback.Exception += OnException;

                    _setter.SetNextAudio(audio);
                    await _setter.PlayNextAudio();

                    _errorCallback.Exception -= OnException;

                    return;

                    void OnException(string error)
                    {
                        Debug.Log($"Exception in controller: {error}");
                        _errorCallback.Exception -= OnException;
                        throw new Exception(error);
                    }
                }
            }
        }

        private async UniTask WaitForVoteEnd(CancellationToken cancellation)
        {
            while (_timeProvider.Duration - _timeProvider.CurrentTime > _options.Vote.VoteStartOffset)
            {
                await UniTask.Yield(cancellation);
            }
        }

        private async UniTask WaitAudioEnd(CancellationToken cancellation)
        {
            while (_timeProvider.CurrentTime < _timeProvider.Duration - 0.5f && _timeProvider.ContainsClip == true)
            {
                await UniTask.Yield(cancellation);
            }
        }
    }
}