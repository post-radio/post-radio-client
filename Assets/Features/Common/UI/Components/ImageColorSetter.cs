using Common.UI.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class ImageColorSetter : MonoBehaviour
    {
        [SerializeField] private UIColor _color;

        private void Awake()
        {
            var image = GetComponent<Image>();
            image.color = _color.Value;
        }

        private void OnDrawGizmos()
        {
            if (_color == null)
                return;

            var image = GetComponent<Image>();
            image.color = _color.Value;
        }
    }
}