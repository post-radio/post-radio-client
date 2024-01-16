using System.Collections.Generic;
using Global.Services.Backend.Abstract;
using ILogger = Internal.Services.Loggers.Runtime.ILogger;

namespace Global.Services.Backend.Logs
{
    public class BackendLogger
    {
        public BackendLogger(ILogger logger, BackendLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly ILogger _logger;
        private readonly BackendLogSettings _settings;

        public void OnGetRequest(IGetRequest request)
        {
            if (_settings.IsAvailable(BackendLogType.Get_Send) == false)
                return;

            _logger.Log($"On {ApplyColor("GET", _settings.GETColor)} " +
                        $"sent to {LogUrl(request.Uri)} \n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        public void OnPostRequest(IPostRequest request)
        {
            if (_settings.IsAvailable(BackendLogType.Post_Send) == false)
                return;

            _logger.Log($"On {ApplyColor("POST", _settings.POSTColor)} " +
                        $"sent to {LogUrl(request.Uri)} " +
                        $"\n{LogHeaders(request.Headers)}\nBody: {request.Body}", _settings.LogParameters);
        }

        public void OnGetError(IGetRequest request, string exception)
        {
            if (_settings.IsAvailable(BackendLogType.Get_Error) == false)
                return;

            _logger.Log($"On {ApplyColor("GET", _settings.GETColor)} sent to {LogUrl(request.Uri)} " +
                        $"exception: {ApplyColor(exception, _settings.ErrorColor)} " +
                        $"\n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        public void OnPostError(IPostRequest request, string exception)
        {
            if (_settings.IsAvailable(BackendLogType.Post_Error) == false)
                return;

            _logger.Log($"On {ApplyColor("POST", _settings.POSTColor)} sent to {LogUrl(request.Uri)} " +
                        $"exception: {ApplyColor(exception, _settings.ErrorColor)} " +
                        $"\n{LogHeaders(request.Headers)}\nBody: {request.Body}", _settings.LogParameters);
        }

        public void OnGetResponse(IGetRequest request, string response)
        {
            if (_settings.IsAvailable(BackendLogType.Get_Response) == false)
                return;

            _logger.Log($"On {ApplyColor("GET", _settings.GETColor)} response from {LogUrl(request.Uri)} " +
                        $": {response} " +
                        $"\n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        public void OnPostResponse(IPostRequest request, string response)
        {
            if (_settings.IsAvailable(BackendLogType.Post_Response) == false)
                return;

            _logger.Log($"On {ApplyColor("POST", _settings.POSTColor)} response from {LogUrl(request.Uri)} " +
                        $": {response} " +
                        $"\n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        public void OnAudioResponse(IGetRequest request)
        {
            if (_settings.IsAvailable(BackendLogType.Audio_Response) == false)
                return;

            _logger.Log($"On {ApplyColor("GET/Audio", _settings.GETColor)} response from {LogUrl(request.Uri)} " +
                        $"\n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        public void OnImageResponse(IGetRequest request)
        {
            if (_settings.IsAvailable(BackendLogType.Image_Response) == false)
                return;

            _logger.Log($"On {ApplyColor("GET/Image", _settings.GETColor)} sent to {LogUrl(request.Uri)} " +
                        $"\n{LogHeaders(request.Headers)}", _settings.LogParameters);
        }

        private string LogHeaders(IReadOnlyList<IRequestHeader> headers)
        {
            var log = "Headers:\n";

            foreach (var header in headers)
                log += $"{ApplyColor($"{header.Type} : {header.Value}", _settings.RequestHeaderColor)}\n";

            return log;
        }

        private string LogUrl(string url)
        {
            var log = string.Empty;
            log += $"URL: {ApplyColor(url, _settings.UrlColor)}";
            return log;
        }

        private string ApplyColor(string log, string color)
        {
#if !UNITY_EDITOR
            return log;
#endif

            return $"<color=#{color}>{log}</color>";
        }
    }
}