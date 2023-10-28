﻿using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;
using UnityEngine;

namespace Global.Publisher.Yandex.Advertisement
{
    public class RewardedHandler
    {
        public RewardedHandler(
            YandexCallbacks callbacks,
            IAdsAPI adsAPI)
        {
            _callbacks = callbacks;
            _api = adsAPI;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly IAdsAPI _api;

        public async UniTask<RewardAdResult> Show()
        {
            var completion = new UniTaskCompletionSource<RewardAdResult>();

            void OnClosed()
            {
                completion.TrySetResult(RewardAdResult.Applied);
            }

            void OnError(string message)
            {
                Debug.LogError($"Interstitial failed: {message}");
                completion.TrySetResult(RewardAdResult.Error);
            }

            _callbacks.RewardedAdClosed += OnClosed;
            _callbacks.RewardedAdError += OnError;

            _api.ShowRewarded_Internal();

            var result = await completion.Task;

            _callbacks.RewardedAdClosed -= OnClosed;
            _callbacks.RewardedAdError -= OnError;

            return result;
        }
    }
}