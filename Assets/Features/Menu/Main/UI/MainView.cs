using Common.UI.Buttons;
using Menu.Common.Navigation;
using TMPro;
using UnityEngine;

namespace Menu.Main.UI
{
    [DisallowMultipleComponent]
    public class MainView : MonoBehaviour, IMainView
    {
        [SerializeField] private ExtendedButton _random;
        [SerializeField] private ExtendedButton _create;
        [SerializeField] private ExtendedButton _withId;
        
        [SerializeField] private GameObject _withIdPanel;
        [SerializeField] private ExtendedButton _withIdApply;
        [SerializeField] private ExtendedButton _withIdCancel;
        [SerializeField] private TMP_InputField _roomId;

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
            _withIdPanel.SetActive(false);

            _interceptor = interceptor;
            _random.Clicked += _interceptor.RandomRequested;
            _create.Clicked += _interceptor.CreateRequested;
            
            _withId.Clicked += WithIdClicked;
            _withIdCancel.Clicked += WithIdCancel;
            _withIdApply.Clicked += WithIdApply;
        }

        public void Dispose()
        {
            _withIdPanel.SetActive(false);
            
            _random.Clicked -= _interceptor.RandomRequested;
            _create.Clicked -= _interceptor.CreateRequested;
            
            _withId.Clicked -= WithIdClicked;
            _withIdCancel.Clicked -= WithIdCancel;
            _withIdApply.Clicked -= WithIdApply;
        }

        public void OnError()
        {
            
        }

        private void WithIdClicked()
        {
            _withIdPanel.SetActive(true);
        }

        private void WithIdApply()
        {
            _interceptor.WithIdRequested(_roomId.text);
        }

        private void WithIdCancel()
        {
            _withIdPanel.SetActive(false);
        }
    }
}