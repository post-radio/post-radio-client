using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Common.Tools.Backend
{
    public class EmptyTransactionalOperation : ResultTransactionalOperation<object>
    {
        public EmptyTransactionalOperation(
            Func<bool, CancellationToken, UniTask> action,
            float timeout = 5f, float retryDelay = 0.5f) : base(
            async (isRetry, cancellation) =>
            {
                await action.Invoke(isRetry, cancellation);
                return new object();
            },
            timeout, retryDelay)
        {
        }
    }
}