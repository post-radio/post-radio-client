using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Events;
using GamePlay.ImageGallery.Backend;
using GamePlay.ImageGallery.Common;
using GamePlay.ImageGallery.UI;
using Global.System.MessageBrokers.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using NovaSamples.UIControls;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GamePlay.ImageGallery.Controller
{
    public class ImageGalleryController : IScopeSwitchListener, IUpdatable
    {
        public ImageGalleryController(
            IUpdater updater,
            IImageGalleryScheme scheme,
            IImageGalleryBackend backend,
            ImageGalleryOptions options)
        {
            _updater = updater;
            _backend = backend;
            _options = options;
            _view = scheme.View;
            _switchButton = scheme.SwitchButton;
            _currentAudio = scheme.CurrentAudio;
        }

        private readonly IImageGalleryView _view;
        private readonly Button _switchButton;
        private readonly IUpdater _updater;
        private readonly IImageGalleryBackend _backend;
        private readonly ImageGalleryOptions _options;
        private readonly ICurrentAudioView _currentAudio;

        private bool _isActive;
        private float _switchTimer;
        private Texture2D _current;
        private IDisposable _audioSwitchListener;

        public void OnEnabled()
        {
            _switchButton.OnClicked.AddListener(OnSwitchClicked);
            _audioSwitchListener = Msg.Listen<SongChangeEvent>(OnSongChanged);
            _currentAudio.Hide();
        }

        public void OnDisabled()
        {
            _switchButton.OnClicked.RemoveListener(OnSwitchClicked);
            _audioSwitchListener?.Dispose();
        }

        private void OnSwitchClicked()
        {
            _isActive = !_isActive;

            if (_isActive == true)
            {
                SwitchImage().Forget();
                _updater.Add(this);
                _view.Open();
                _currentAudio.Show();
            }
            else
            {
                _updater.Remove(this);
                _view.Close();
                _currentAudio.Hide();
            }

            _switchTimer = 0f;
        }

        public void OnUpdate(float delta)
        {
            _switchTimer += delta;
            
            if (_switchTimer < _options.SwitchDelay)
                return;

            _switchTimer = 0f;
            SwitchImage().Forget();
        }

        private async UniTask SwitchImage()
        {
            var image = await _backend.LoadRandom();
            
            if (image == null)
                return;

            await _view.SetImage(image);
            
            if (_current != null)
                Object.Destroy(_current);

            await UniTask.Yield();
            
            _current = image;
        }
        
        private void OnSongChanged(SongChangeEvent payload)
        {
            _currentAudio.Construct(payload.AudioData.Author, payload.AudioData.Title);
        }
    }
}