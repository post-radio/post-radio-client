using Internal.Services.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Internal.Services.Loggers.Runtime.Headers
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.HeaderName,
        menuName = LoggerRoutes.HeaderPath)]
    public class LoggerHeader : ScriptableObject
    {
        [SerializeField] [HideLabel] private string _name;

        [SerializeField] private bool _isColored = true;

        [ShowIf("_isColored")] [SerializeField] [ColorPalette("LogHeader")] [HideLabel]
        private Color _color;

        public string Name => _name;
        public bool IsColored => _isColored;
        public string Color => ColorUtility.ToHtmlStringRGB(_color);
    }
}