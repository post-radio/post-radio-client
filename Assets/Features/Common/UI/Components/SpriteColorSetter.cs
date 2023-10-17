using Common.UI.Definitions;
using UnityEngine;

namespace Common.UI.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteColorSetter : MonoBehaviour
    {
        [SerializeField] private UIColor _color;

        private void Awake()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = _color.Value;
        }

        private void OnDrawGizmos()
        {
            if (_color == null)
                return;
            
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = _color.Value;
        }
    }
}