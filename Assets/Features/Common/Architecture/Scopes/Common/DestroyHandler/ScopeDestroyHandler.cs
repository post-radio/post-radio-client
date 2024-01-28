using Common.Architecture.Scopes.Runtime.Callbacks;
using UnityEngine;

namespace Common.Architecture.Scopes.Common.DestroyHandler
{
    [DisallowMultipleComponent]
    public class ScopeDestroyHandler : MonoBehaviour
    {
        private IScopeCallbacks _callbacks;
        
        public void Construct(IScopeCallbacks callbacks)
        {
            _callbacks = callbacks;
        }

        private void OnDestroy()
        {
            _callbacks.Handlers[CallbackStage.Dispose].Run().GetAwaiter().GetResult();
        }
    }
}