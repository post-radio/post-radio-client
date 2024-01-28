using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Player.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio.Player.Loading
{
    [DisallowMultipleComponent]
    public class AudioPlayerSource : MonoBehaviour, IAudioPlayerSource, IAudioTimeProvider
    {
        private const float PlayTimeout = 3f;
        private const float PlayEpsilon = 0.01f;

        [SerializeField] private AudioSource _source;

        private bool _isTimeoutActive;

        public float CurrentTime => GetTime();

        public float Duration => GetDuration();

        public bool ContainsClip => _source.clip != null;

        public void SetVolume(float volume)
        {
            _source.volume = volume;
        }

        public async UniTask<UniTask> Play(AudioClip clip, float delay, CancellationToken cancellation)
        {
            _isTimeoutActive = true;
            _source.clip = clip;
            _source.Play();

            await HandleTimout();

            if (_isTimeoutActive == true)
            {
                _isTimeoutActive = false;
                return UniTask.CompletedTask;
            }

            return WaitAudioEnd();

            async UniTask HandleTimout()
            {
                var timer = 0f;

                while (timer < PlayTimeout)
                {
                    if (_source.clip != null && _source.clip.length > PlayEpsilon)
                    {
                        _source.time = delay;
                        _isTimeoutActive = false;
                        return;
                    }

                    timer += Time.deltaTime;
                    await UniTask.Yield(cancellation);
                }
            }

            async UniTask WaitAudioEnd()
            {
                while (_source.time < _source.clip.length - 0.1f)
                    await UniTask.Yield(cancellation);
            }
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
            if (_isTimeoutActive == true)
                return float.MaxValue;

            if (_source.clip == null)
                return 0f;

            return _source.clip.length;
        }

        [Button]
        private void Skip()
        {
            _source.time = _source.clip.length - 7f;
        }
    }
}