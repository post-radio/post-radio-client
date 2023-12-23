using Global.UI.Nova.Components;
using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class MainView : MonoBehaviour, IMainView
    {
        [SerializeField] private UIButton _play;
        [SerializeField] private Transform _targetCameraPoint;
        
        private ITabNavigation _navigation;
        private RectTransform _transform;
        private IMainInterceptor _interceptor;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;
        public Transform TargetCameraPoint => _targetCameraPoint;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }

        public void Construct(IMainInterceptor interceptor)
        {
            _interceptor = interceptor;
            _play.Clicked += _interceptor.CreateRequested;
        }

        public void Dispose()
        {
            _play.Clicked -= _interceptor.CreateRequested;
        }

        public void OnError()
        {
            
        }
    }
}