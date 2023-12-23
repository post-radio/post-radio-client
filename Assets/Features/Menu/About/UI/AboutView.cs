using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.About.UI
{
    [DisallowMultipleComponent]
    public class AboutView : MonoBehaviour, IAboutView
    {
        private ITabNavigation _navigation;
        private RectTransform _transform;

        public ITabNavigation Navigation => _navigation;
        public RectTransform Transform => _transform;

        private void Awake()
        {
            _navigation = GetComponent<ITabNavigation>();
            _transform = GetComponent<RectTransform>();
        }
    }
}