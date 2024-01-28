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

                if (isRetry == true)
                    Debug.Log("Start transaction retry");
                
                try
                {
                    WaitTimeout(cancellation.Token).Forget();
                    result = await _action.Invoke(isRetry, cancellation.Token);
                    isSuccess = true;
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

                if (isRetry == true)
                    Debug.Log("Transaction completed with retry");

                cancellation?.Cancel();
                cancellation?.Dispose();
            }

            return result;
            
            async UniTask WaitTimeout(CancellationToken timeoutCancellation)
            {
                var timer = 0f;

                while (timer < _timeout)
                {
                    timer += Time.deltaTime;
                    await UniTask.Yield(timeoutCancellation);
                }
                
                isSuccess = false;
                isRetry = true;

                Debug.Log("On timeout");
            }
        }
    }
}