using Common.UI.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.Definitions
{
    [InlineEditor]
    [CreateAssetMenu(menuName = ExtendedRoutes.EntryPath + "Color", fileName = "Color")]
    public class UIColor : ScriptableObject
    {
        [SerializeField] private Color _value;

        public Color Value => _value;
    }
}