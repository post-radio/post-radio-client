using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.Cameras.Persistent.Logs;
using UnityEngine;
using VContainer;

namespace Global.Cameras.Persistent.Runtime
{
    [DisallowMultipleComponent]
    public class GlobalCamera : MonoBehaviour, IGlobalCamera, IScopeAwakeListener
    {
        [Inject]
        private void Construct(GlobalCameraLogger logger)
        {
            _logger = logger;
        }

        private GlobalCameraLogger _logger;

        public Camera Camera { get; private set; }

        public void OnAwake()
        {
            Camera = GetComponent<Camera>();
        }

        public void Enable()
        {
            gameObject.SetActive(true);

            _logger.OnEnabled();
        }

        public void Disable()
        {
            gameObject.SetActive(false);

            _logger.OnDisabled();
        }
    }
}