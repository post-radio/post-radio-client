using System;
using Common.Architecture.Scopes.Runtime.Callbacks;
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
            IGlobalVolume globalVolume,
            AudioOverlayConfig config)
        {
            _updater = updater;
            _timeProvider = timeProvider;
            _globalVolume = globalVolume;
            _config = config;
            _progressBar = scheme.ProgressBar;
            _audioSlider = scheme.AudioSlider;
            _volumeButton = scheme.VolumeButton;
            _volumeImage = scheme.VolumeImage;
            _songDataText = scheme.SongDataText;
        }

        private readonly IUpdater _updater;
        private readonly IAudioTimeProvider _timeProvider;
        private readonly IGlobalVolume _globalVolume;
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
            _audioSlider.Value = _globalVolume.Music * 100f;
            _savedMusicVolume = _globalVolume.Music;
            _audioSlider.OnValueChanged.AddListener(OnSliderValueChanged);
            _volumeButton.OnClicked.AddListener(OnVolumeButtonClicked);

            if (_globalVolume.Music > 0f)
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
                _globalVolume.SaveVolume();
            }

            var progress = _timeProvider.CurrentTime / _timeProvider.Duration;

            _progressBar.Percent = progress;

            if (_globalVolume.Music > 0f)
                _volumeImage.SetImage(_config.EnabledVolumeSprite);
            else
                _volumeImage.SetImage(_config.DisabledVolumeSprite);
        }

        private void OnSliderValueChanged(float value)
        {
            _globalVolume.SetVolume(value / 100f, _globalVolume.Sound);
        }

        private void OnVolumeButtonClicked()
        {
            if (_globalVolume.Music > 0f)
            {
                _savedMusicVolume = _globalVolume.Music;
                _globalVolume.SetVolume(0f, _globalVolume.Sound);
                _volumeImage.SetImage(_config.DisabledVolumeSprite);
                _audioSlider.Value = 0f;
            }
            else if (Mathf.Approximately(_globalVolume.Music, 0f) == true)
            {
                _globalVolume.SetVolume(_savedMusicVolume, _globalVolume.Sound);
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