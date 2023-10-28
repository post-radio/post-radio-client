﻿using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Advertisment;
using Global.Publisher.Yandex.Common;
using UnityEngine;

namespace Global.Publisher.Yandex.Advertisement
{
    public class InterstitialHandler
    {
        public InterstitialHandler(
            YandexCallbacks callbacks,
            IAdsAPI adsAPI)
        {
            _callbacks = callbacks;
            _api = adsAPI;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly IAdsAPI _api;

        private UniTaskCompletionSource<InterstitialResult> _completion;

        public async UniTask Show()
        {
            var completion = new UniTaskCompletionSource<InterstitialResult>();

            void OnShown()
            {
                completion.TrySetResult(InterstitialResult.Success);
            }

            void OnFailed(string message)
            {
                Debug.LogError($"Interstitial failed: {message}");
                completion.TrySetResult(InterstitialResult.Fail);
            }

            _callbacks.InterstitialShown += OnShown;
            _callbacks.InterstitialFailed += OnFailed;

            _api.ShowInterstitial_Internal();

            await completion.Task;

            _callbacks.InterstitialShown -= OnShown;
            _callbacks.InterstitialFailed -= OnFailed;
        }
    }
}