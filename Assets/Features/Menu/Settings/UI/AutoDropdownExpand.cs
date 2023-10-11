using UnityEngine;

namespace Menu.Settings.UI
{
    [DisallowMultipleComponent]
    public class AutoDropdownExpand : MonoBehaviour
    {
        [SerializeField] private RectTransform _root;
        [SerializeField] private float _elementHeight;

        private RectTransform _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            var elementsCount = _root.childCount;
            _transform.sizeDelta = new Vector2(_transform.sizeDelta.x, _elementHeight * elementsCount);
        }
    }
}