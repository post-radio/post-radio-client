using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.Backend
{
    public class ResultTransactionalOperation<T> where T : class
    {
        public ResultTransactionalOperation(
            Func<bool, CancellationToken, UniTask<T>> action,
            float timeout,
            float retryDelay)
        {
            _action = action;
            _timeout = timeout;
            _retryDelay = retryDelay;
        }

        private readonly Func<bool, CancellationToken, UniTask<T>> _action;
        private readonly float _timeout;
        private readonly float _retryDelay;

        public async UniTask<T> Run()
        {
            var isSuccess = false;
            var isRetry = false;
            T result = null;

            while (isSuccess == false)
            {
                var cancellation = new CancellationTokenSource();

                try
                {
                    isSuccess = true;
                    WaitTimeout(cancellation.Token).Forget();
                    result = await _action.Invoke(isRetry, cancellation.Token);

                    async UniTask WaitTimeout(CancellationToken timeoutCancellation)
                    {
                        await UniTask.Delay(_timeout, timeoutCancellation);

                        isSuccess = false;
                        isRetry = true;

                        Debug.Log("On timeout");
                    }
                }
                catch (Exception exception)
                {
                    Debug.Log($"Exception in result transaction: {exception.Message}");

                    cancellation.Cancel();
                    cancellation.Dispose();
                    cancellation = null;

                    isSuccess = false;
                    isRetry = true;

                    await UniTask.Delay(_retryDelay);
                }

                cancellation?.Cancel();
                cancellation?.Dispose();
            }

            return result;
        }
    }
}