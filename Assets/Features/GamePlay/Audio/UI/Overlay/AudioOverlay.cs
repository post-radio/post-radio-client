using System;
using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using GamePlay.Audio.Events;
using GamePlay.Audio.Player.Abstract;
using Global.Audio.Player.Runtime;
using Global.System.MessageBrokers.Runtime;
using Global.System.Updaters.Runtime.Abstract;
using Nova;
using NovaSamples.UIControls;
using UnityEngine;

namespace GamePlay.Audio.UI.Overlay
{
    public class AudioOverlay : IScopeSwitchListener, IUpdatable
    {
        public AudioOverlay(
            IUpdater updater,
            IAudioTimeProvider timeProvider,
            IAudioOverlayScheme scheme,
            IVolumeSetter volumeSetter,
            AudioOverlayConfig config)
        {
            _updater = updater;
            _timeProvider = timeProvider;
            _volumeSetter = volumeSetter;
            _config = config;
            _progressBar = scheme.ProgressBar;
            _audioSlider = scheme.AudioSlider;
            _volumeButton = scheme.VolumeButton;
            _volumeImage = scheme.VolumeImage;
            _songDataText = scheme.SongDataText;
        }

        private readonly IUpdater _updater;
        private readonly IAudioTimeProvider _timeProvider;
        private readonly IVolumeSetter _volumeSetter;
        private readonly AudioOverlayConfig _config;
        private readonly ProgressBar _progressBar;
        private readonly Slider _audioSlider;
        private readonly Button _volumeButton;
        private readonly UIBlock2D _volumeImage;
        private readonly TextBlock _songDataText;

        private const float VolumeSaveDelay = 10f;
        
        private float _volumeSaveTimer;
        private float _savedMusicVolume = 1f;

        private IDisposable _songChangeListener;

        public void OnEnabled()
        {
            _updater.Add(this);
            _audioSlider.Value = _volumeSetter.Music * 100f;
            _savedMusicVolume = _volumeSetter.Music;
            _audioSlider.OnValueChanged.AddListener(OnSliderValueChanged);
            _volumeButton.OnClicked.AddListener(OnVolumeButtonClicked);

            if (_volumeSetter.Music > 0f)
                _volumeImage.SetImage(_config.EnabledVolumeSprite);
            else
                _volumeImage.SetImage(_config.DisabledVolumeSprite);

            _songChangeListener = Msg.Listen<SongChangeEvent>(OnSongChanged);
        }

        public void OnDisabled()
        {
            _updater.Remove(this);
            _audioSlider.OnValueChanged.RemoveListener(OnSliderValueChanged);
            _volumeButton.OnClicked.RemoveListener(OnVolumeButtonClicked);
            
            _songChangeListener?.Dispose();
        }

        public void OnUpdate(float delta)
        {
            _volumeSaveTimer += delta;

            if (_volumeSaveTimer > VolumeSaveDelay)
            {
                _volumeSaveTimer = 0f;
                _volumeSetter.SaveVolume();
            }

            var progress = _timeProvider.CurrentTime / _timeProvider.Duration;

            _progressBar.Percent = progress;

            if (_volumeSetter.Music > 0f)
                _volumeImage.SetImage(_config.EnabledVolumeSprite);
            else
                _volumeImage.SetImage(_config.DisabledVolumeSprite);
        }

        private void OnSliderValueChanged(float value)
        {
            _volumeSetter.SetVolume(value / 100f, _volumeSetter.Sound);
        }

        private void OnVolumeButtonClicked()
        {
            if (_volumeSetter.Music > 0f)
            {
                _savedMusicVolume = _volumeSetter.Music;
                _volumeSetter.SetVolume(0f, _volumeSetter.Sound);
                _volumeImage.SetImage(_config.DisabledVolumeSprite);
                _audioSlider.Value = 0f;
            }
            else if (Mathf.Approximately(_volumeSetter.Music, 0f) == true)
            {
                _volumeSetter.SetVolume(_savedMusicVolume, _volumeSetter.Sound);
                _volumeImage.SetImage(_config.EnabledVolumeSprite);
                _audioSlider.Value = _savedMusicVolume * 100f;
            }
        }

        private void OnSongChanged(SongChangeEvent data)
        {
            _songDataText.Text = $"{data.AudioData.Author} - {data.AudioData.Title}";
        }
    }
}