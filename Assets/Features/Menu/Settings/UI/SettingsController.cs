﻿using System.Threading;
using Cysharp.Threading.Tasks;
using Global.Audio.Player.Runtime;
using Global.Localizations.Definition;
using Global.Localizations.Runtime;
using Global.Publisher.Abstract.DataStorages;
using Global.System.Updaters.Runtime.Abstract;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Settings.UI
{
    public class SettingsController : ISettingsController, ITab, IUpdatable
    {
        public SettingsController(
            ISettingsView view,
            IVolumeSetter volumeSetter,
            ILanguageConverter languageConverter,
            ILocalization localization,
            IDataStorage dataStorage,
            IUpdater updater)
        {
            _view = view;
            _volumeSetter = volumeSetter;
            _languageConverter = languageConverter;
            _localization = localization;
            _dataStorage = dataStorage;
            _updater = updater;
        }

        private readonly ISettingsView _view;
        private readonly IVolumeSetter _volumeSetter;
        private readonly ILanguageConverter _languageConverter;
        private readonly ILocalization _localization;
        private readonly IDataStorage _dataStorage;
        private readonly IUpdater _updater;

        public RectTransform Transform => _view.Transform;

        public async UniTask Activate(CancellationToken cancellation)
        {
            _updater.Add(this);

            var save = await _dataStorage.GetEntry<SoundSave>(SoundSave.Key);

            _view.SetSlidersValue(save.Value.MusicVolume, save.Value.SoundVolume);
            _view.Navigation.Enable();
            
            _view.SetLanguage(_localization.Language);
            
            _view.LanguageChanged += OnLanguageChanged;
            _view.SocialClicked += OnSocialClicked;
        }

        public void Deactivate()
        {
            _updater.Remove(this);
            
            _view.Navigation.Disable();
            
            _volumeSetter.SetVolume(_view.MusicValue, _view.SoundValue);
            _volumeSetter.SaveVolume();
        }

        private void OnLanguageChanged(Language language)
        {
            _localization.Set(language);
        }

        private void OnSocialClicked()
        {
        }

        public void OnUpdate(float delta)
        {
            _volumeSetter.SetVolume(_view.MusicValue, _view.SoundValue);
        }
    }
}