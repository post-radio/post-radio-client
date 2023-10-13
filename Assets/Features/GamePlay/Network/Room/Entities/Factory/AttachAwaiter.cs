using Cysharp.Threading.Tasks;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Network.Room.Entities.Factory
{
    public readonly struct AttachAwaiter
    {
        public AttachAwaiter(RagonEntity entity)
        {
            _entity = entity;
        }
        
        private readonly RagonEntity _entity;

        public async UniTask WaitAttachAsync()
        {
            var completion = new UniTaskCompletionSource();
            
            void OnAttached(RagonEntity entity)
            {
                completion.TrySetResult();
            }

            _entity.Attached += OnAttached;

            await completion.Task;
            
            _entity.Attached -= OnAttached;
        }
    }
}