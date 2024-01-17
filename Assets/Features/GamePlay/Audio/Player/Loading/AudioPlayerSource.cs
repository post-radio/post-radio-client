using Cysharp.Threading.Tasks;
using GamePlay.Audio.Player.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Player.Loading
{
    [DisallowMultipleComponent]
    public class AudioPlayerSource : MonoBehaviour, IAudioPlayerSource, IAudioTimeProvider
    {
        [SerializeField] private AudioSource _source;

        public float CurrentTime => GetTime();

        public float Duration => GetDuration();

        public bool ContainsClip => _source.clip != null;

        public void SetVolume(float volume)
        {
            _source.volume = volume;
        }

        public async UniTask Play(AudioClip clip, float delay)
        {
            _source.clip = clip;
            _source.Play();
            
            await UniTask.WaitUntil(() => _source.clip.length > 0.1f);
            _source.time = delay;
        }
        
        public void Reset()
        {
            _source.Stop();
            _source.clip = null;
        }

        private float GetTime()
        {
            return _source.isPlaying == true ? _source.time : 0f;
        }

        private float GetDuration()
        {
            if (_source.clip == null)
                return float.MaxValue;

            if (Mathf.Approximately(_source.clip.length, 0f) == true)
                return float.MaxValue;

            return _source.clip.length;
        }

        [Button]
        private void Skip()
        {
            _source.time = _source.clip.length - 7f;
        }
    }
}