using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Audio.Player.Abstract;
using Global.System.Updaters.Delays;
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
        private IDelayRunner _delayRunner;

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
            _source.clip = null;
            var timeoutTask = HandleTimout();

            try
            {
                _source.clip = clip;
                _source.Play();
            }
            catch
            {
                _isTimeoutActive = false;
                _source.clip = null;
                return UniTask.CompletedTask;
            }

            await timeoutTask;

            if (_isTimeoutActive == false)
                return WaitAudioEnd();
            
            _isTimeoutActive = false;
            _source.clip = null;
            return UniTask.CompletedTask;

            async UniTask HandleTimout()
            {
                var timer = 0f;

                while (timer < PlayTimeout)
                {
                    if (_isTimeoutActive == false)
                        return;
                    
                    if (_source.clip != null && _source.time > PlayEpsilon)
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