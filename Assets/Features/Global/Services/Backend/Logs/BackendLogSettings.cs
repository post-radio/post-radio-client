using Global.Backend.Common;
using Internal.Services.Loggers.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Backend.Logs
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BackendRoutes.LogsName,
        menuName = BackendRoutes.LogsPath)]
    public class BackendLogSettings : LogSettings<BackendLogs, BackendLogType>
    {
        [SerializeField] private LogParameters _parameters;
        [SerializeField] [ColorPalette] private Color _requestHeaderColor;
        [SerializeField] [ColorPalette] private Color _urlColor;
        [SerializeField] [ColorPalette] private Color _getColor;
        [SerializeField] [ColorPalette] private Color _postColor;
        [SerializeField] [ColorPalette] private Color _errorColor;

        public LogParameters LogParameters => _parameters;
        public string RequestHeaderColor => ColorUtility.ToHtmlStringRGB(_requestHeaderColor);
        public string UrlColor => ColorUtility.ToHtmlStringRGB(_urlColor);
        public string GETColor => ColorUtility.ToHtmlStringRGB(_getColor);
        public string POSTColor => ColorUtility.ToHtmlStringRGB(_postColor);
        public string ErrorColor => ColorUtility.ToHtmlStringRGB(_errorColor);
    }
}