using System;
using Common.Architecture.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Services.VfxPools.Runtime
{
    [DisallowMultipleComponent]
    public class VfxAnimatedObject : MonoBehaviour, IPoolObject
    {
        [SerializeField] private Animator _animator;

        private Action<IPoolObject> _returnToPool;

        private UniTaskCompletionSource _completion;

        private static readonly int _play = Animator.StringToHash("Play");

        public GameObject GameObject => gameObject;

        public void Construct(Action<IPoolObject> returnToPool)
        {
            _returnToPool = returnToPool;
        }

        public void OnTaken()
        {
            OnReturned();

            _completion = new UniTaskCompletionSource();

            Play().Forget();
        }

        public void OnReturned()
        {
            _completion?.TrySetCanceled();
            _completion = null;
        }

        public void OnPlayed_AnimatorCallback()
        {
            _completion?.TrySetResult();
        }

        private async UniTask Play()
        {
            _animator.SetTrigger(_play);

            await _completion.Task;

            _returnToPool?.Invoke(this);
        }
    }
}