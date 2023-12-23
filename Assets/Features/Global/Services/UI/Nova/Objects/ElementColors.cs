using Global.UI.Nova.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Nova.Objects
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NovaRoutes.ButtonColorsName, menuName = NovaRoutes.ButtonColorsPath)]
    public class ElementColors : ScriptableObject
    {
        [SerializeField] private Color _idle = new(0f, 0f, 0f, 1f);
        [SerializeField] private Color _hovered = new(0f, 0f, 0f, 1f);
        [SerializeField] private Color _pressed = new(0f, 0f, 0f, 1f);

        public Color Idle => _idle;
        public Color Hovered => _hovered;
        public Color Pressed => _pressed;
    }
}