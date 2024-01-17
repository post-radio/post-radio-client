using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Common.Tools.Backend
{
    public static class Transactions
    {
        public static UniTask<T> Run<T>(
            Func<bool, CancellationToken, UniTask<T>> action,
            float timeout = 15f,
            float retryDelay = 0.5f) where T : class
        {
            return new ResultTransactionalOperation<T>(action, timeout, retryDelay).Run();
        }

        public static UniTask Run(
            Func<bool, CancellationToken, UniTask> action,
            float timeout = 15f,
            float retryDelay = 0.5f)
        {
            return new EmptyTransactionalOperation(action, timeout, retryDelay).Run();
        }
    }
}