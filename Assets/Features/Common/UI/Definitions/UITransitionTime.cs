using Common.UI.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.UI.Definitions
{
    [InlineEditor]
    [CreateAssetMenu(menuName = ExtendedRoutes.EntryPath + "TransitionTime", fileName = "TransitionTime")]
    public class UITransitionTime : ScriptableObject
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}