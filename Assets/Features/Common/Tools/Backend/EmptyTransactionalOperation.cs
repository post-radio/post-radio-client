using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.Backend
{
    public class EmptyTransactionalOperation
    {
        public EmptyTransactionalOperation(Func<bool, UniTask> action, float retryDelay = 0.5f)
        {
            _action = action;
            _retryDelay = retryDelay;
        }
        
        private readonly Func<bool, UniTask> _action;
        private readonly float _retryDelay;

        public async UniTask Run()
        {
            var isSuccess = false;
            var isRetry = false;
            
            while (isSuccess == false)
            {
                try
                {
                    isSuccess = true;
                    await _action.Invoke(isRetry);
                }
                catch (Exception exception)
                {
                    isSuccess = false;
                    isRetry = true;
                    Debug.Log($"Exception in empty transaction: {exception.Message}");
                    await UniTask.Delay(_retryDelay);
                }
            }
        }
    }
}