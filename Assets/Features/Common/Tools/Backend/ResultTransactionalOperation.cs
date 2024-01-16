using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.Backend
{
    public class ResultTransactionalOperation<T> where T : class
    {
        public ResultTransactionalOperation(Func<bool, UniTask<T>> action, float retryDelay = 0.5f)
        {
            _action = action;
            _retryDelay = retryDelay;
        }
        
        private readonly Func<bool, UniTask<T>> _action;
        private readonly float _retryDelay;

        public async UniTask<T> Run()
        {
            var isSuccess = false;
            var isRetry = false;
            T result = null;
            
            while (isSuccess == false)
            {
                try
                {
                    isSuccess = true;
                    result = await _action.Invoke(isRetry);
                }
                catch (Exception exception)
                {
                    Debug.Log($"Exception in result transaction: {exception.Message}");

                    isSuccess = false;
                    isRetry = true;
                    await UniTask.Delay(_retryDelay);
                }
            }

            return result;
        }
    }
}