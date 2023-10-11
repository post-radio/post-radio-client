using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using UnityEngine;
using VContainer;

namespace Global.System.DestroyHandlers.Runtime
{
    [DisallowMultipleComponent]
    public class DestroyHandler : MonoBehaviour
    {
        [Inject]
        private void Construct(IScopeCallbacks callbacks)
        {
            _callbacks = callbacks;
        }
        
        private IScopeCallbacks _callbacks;
        
        private void OnDestroy()
        {
            _callbacks.Handlers[CallbackStage.Dispose].Run().GetAwaiter().GetResult();
        }
    }
}