using Common.Architecture.ScopeLoaders.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using UnityEngine;
using VContainer;

namespace Global.Audio.Player.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsPlayer : MonoBehaviour, IScopeEnableAsyncListener, IVolumeSetter
    {
        [Inject]
        private void Construct(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource[] _soundSources;

        private IDataStorage _dataStorage;

        private float _musicVolume;
        private float _soundVolume;

        public async UniTask OnEnabledAsync()
        {
            var save = await _dataStorage.GetEntry<SoundSave>(SoundSave.Key);

            SetVolume(save.Value.MusicVolume, save.Value.SoundVolume);
        }

        public void Mute()
        {
            ApplyVolume(0f, 0f);
        }

        public void Unmute()
        {
            ApplyVolume(_musicVolume, _soundVolume);
        }

        public void SaveVolume()
        {
            var save = new SoundSave()
            {
                Value = new SoundSavePayload()
                {
                    MusicVolume = _musicVolume,
                    SoundVolume = _soundVolume
                }
            };

            _dataStorage.Save(save, SoundSave.Key);
        }

        public void SetVolume(float music, float sound)
        {
            _musicVolume = music;
            _soundVolume = sound;

            ApplyVolume(_musicVolume, _soundVolume);
        }

        private void ApplyVolume(float music, float sound)
        {
            _musicSource.volume = music;

            foreach (var source in _soundSources)
                source.volume = sound;
        }

        public void PlaySound(AudioClip clip)
        {
            foreach (var source in _soundSources)
            {
                if (source.isPlaying == true)
                    continue;

                source.clip = clip;
                source.Play();
            }

            _soundSources[0].clip = clip;
            _soundSources[0].Play();
        }

        public void PlayLoopMusic(AudioClip clip)
        {
            _musicSource.loop = true;
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }
}