using System;
using Cysharp.Threading.Tasks;

namespace Common.Tools.Backend
{
    public static class Transactions
    {
        public static UniTask<T> Run<T>(Func<bool, UniTask<T>> action, float retryDelay = 0.5f) where T : class
        {
            return new ResultTransactionalOperation<T>(action, retryDelay).Run();
        }
        
        public static UniTask Run(Func<bool, UniTask> action, float retryDelay = 0.5f)
        {
            return new EmptyTransactionalOperation(action, retryDelay).Run();
        }
    }
}