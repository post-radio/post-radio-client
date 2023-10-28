﻿using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Common;
using Global.System.Pauses.Runtime;

namespace Global.Publisher.Yandex.Review
{
    public class Reviews : IReviews
    {
        public Reviews(YandexCallbacks callbacks, IPause pause, IReviewsAPI api)
        {
            _callbacks = callbacks;
            _pause = pause;
            _api = api;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly IPause _pause;
        private readonly IReviewsAPI _api;

        private bool _isReviewed;

        public async UniTask Review()
        {
            if (_isReviewed == true)
                return;

            _pause.Pause();

            var completion = new UniTaskCompletionSource();

            void OnReviewed()
            {
                completion.TrySetResult();
            }

            _callbacks.Reviewed += OnReviewed;

            _api.Review_Internal();

            _isReviewed = true;

            await completion.Task;

            _callbacks.Reviewed -= OnReviewed;

            _pause.Continue();
        }
    }
}