using System.Runtime.InteropServices;
using System.Threading;
using Common.UI.Definitions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GamePlay.Audio.UI.Voting.UI.Suggestion.Abstract;
using Nova;
using NovaSamples.UIControls;
using UnityEngine;

namespace GamePlay.Audio.UI.Voting.UI.Suggestion
{
    [DisallowMultipleComponent]
    public class SuggestionView : MonoBehaviour, ISuggestionView
    {
        [DllImport("__Internal")]
        private static extern string GetClipboard();
        
        [SerializeField] private UIColor _acceptColor;
        [SerializeField] private UIColor _cancelColor;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private UIBlock2D _image;
        
        [SerializeField] private float _shakeScale = 1.1f;
        [SerializeField] private float _shakeStrength = 50f;
        [SerializeField] private int _shakeVibration = 50;
        [SerializeField] private UITransitionTime _switchTime;

        [SerializeField] private TextField _input;
        [SerializeField] private Button _sendButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Button _clipboardButton;
        [SerializeField] private SuggestionLoadingView _loadingView;
        
        private ISuggestionInterceptor _interceptor;

        public void Construct(ISuggestionInterceptor interceptor)
        {
            _interceptor = interceptor;
        }

        private void OnEnable()
        {
            _sendButton.OnClicked.AddListener(OnSendClicked);
            _cancelButton.OnClicked.AddListener(OnCancelClicked);
            _clipboardButton.OnClicked.AddListener(OnClipboardClicked);
            _sendButton.enabled = true;
        }

        private void OnDisable()
        {
            _loadingView.Disable();
            
            _sendButton.OnClicked.RemoveListener(OnSendClicked);
            _cancelButton.OnClicked.RemoveListener(OnCancelClicked);
            _clipboardButton.OnClicked.RemoveListener(OnClipboardClicked);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnSendClicked()
        {
            if (string.IsNullOrWhiteSpace(_input.Text) == true)
                return;
            
            _loadingView.Enable();

            var url = _input.Text;
            _input.Text = string.Empty;
            _interceptor.OnRequest(url);
        }

        private void OnCancelClicked()
        {
            _interceptor.OnCloseClicked();
        }

        private void OnClipboardClicked()
        {
            _input.Text = GetClipboard();
        }

        public async UniTask OnSuccess(CancellationToken cancellation)
        {
            await UniTask.Delay(0.5f, cancellation);
            _loadingView.Disable();
            _sendButton.enabled = false;
            
            var colorTask = ColorTransition(_acceptColor.Value, _switchTime.Value, cancellation);
            var shakeTask = Shake(_shakeScale, _switchTime.Value, cancellation);

            await UniTask.WhenAll(colorTask, shakeTask);

            gameObject.SetActive(false);
        }

        public async UniTask OnFail(CancellationToken cancellation)
        {
            await UniTask.Delay(0.5f, cancellation);
            _loadingView.Disable();
            _sendButton.enabled = false;
  
            var colorTask = ColorTransition(_cancelColor.Value, _switchTime.Value, cancellation);
            var shakeTask = Shake(_shakeScale, _switchTime.Value, cancellation);
            
            await UniTask.WhenAll(colorTask, shakeTask);
            
            _sendButton.enabled = true;
        }

        private async UniTask ColorTransition(Color targetColor, float time, CancellationToken cancellation)
        {
            var currentTime = 0f;
            var progress = 0f;
            var startColor = _image.Color;

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                _image.Color = Color.Lerp(startColor, targetColor, progress);

                await UniTask.Yield(cancellation);
            }
            
            currentTime = 0f;
            progress = 0f;
            
            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                _image.Color = Color.Lerp(targetColor, startColor, progress);
                
                await UniTask.Yield(cancellation);
            }
        }

        private async UniTask Shake(float targetScale, float time, CancellationToken cancellation)
        {
            var currentTime = 0f;
            var progress = 0f;
            _transform.DOShakeRotation(duration: time, strength: _shakeStrength, vibrato: _shakeVibration);

            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                _transform.localScale = Vector3.one + (Vector3.one * targetScale * progress);
                
                await UniTask.Yield(cancellation);
            }

            currentTime = 0f;
            progress = 0f;
            
            while (progress < 1f)
            {
                currentTime += Time.deltaTime;
                progress = currentTime / time;

                _transform.localScale = Vector3.one + (Vector3.one * targetScale * (1f - progress));
                
                await UniTask.Yield(cancellation);
            }
        }
    }
}