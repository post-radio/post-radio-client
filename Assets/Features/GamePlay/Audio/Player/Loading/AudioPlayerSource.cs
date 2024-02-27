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
        private const float PlayEpsilon = 0.5f;

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

        public void Clear()
        {
            _source.clip = null;
            _isTimeoutActive = false;
        }

        public async UniTask<UniTask> Play(AudioClip clip, float delay, CancellationToken cancellation)
        {
            Debug.Log($"[Audio] 5 Play");

            _isTimeoutActive = true;
            _source.clip = null;
            var timeoutTask = HandleTimout();

            try
            {
                _source.clip = clip;
                _source.Play();
            }
            catch (Exception exception)
            {
                _isTimeoutActive = false;
                _source.clip = null;
                Debug.Log($"[Audio] 7 source play exception: {exception.Message}");

                return UniTask.CompletedTask;
            }

            Debug.Log($"[Audio] 8 wait timeout");

            await timeoutTask;

            if (_isTimeoutActive == false)
            {
                Debug.Log($"[Audio] 9 successful play");

                return WaitAudioEnd();
            }

            Debug.Log($"[Audio] 10 play failed, return CompletedTask");

            _isTimeoutActive = false;
            _source.clip = null;
            return UniTask.CompletedTask;

            async UniTask HandleTimout()
            {
                Debug.Log($"[Audio] 6 Handle timeout");

                var timer = 0f;

                while (timer < PlayTimeout)
                {
                    if (_isTimeoutActive == false)
                    {
                        Debug.Log($"[Audio] 6.1 Handle timeout: exit with _isTimeoutActive = false");

                        return;
                    }

                    if (_source.clip != null && _source.time > PlayEpsilon)
                    {
                        Debug.Log($"[Audio] 6.2 Handle timeout: exit with {_source.time} > {PlayEpsilon}");
                        _source.time = delay;
                        _isTimeoutActive = false;
                        return;
                    }

                    Debug.Log($"[Audio] 6.3 Handle timeout: timer: {timer}");

                    timer += Time.deltaTime;
                    await UniTask.Yield(cancellation);
                }
            }

            async UniTask WaitAudioEnd()
            {
                Debug.Log($"[Wait] WaitAudioEnd start");

                await UniTask.Delay(PlayEpsilon * 2f, cancellation);
                
                while (_source.clip != null && _source.isPlaying == true && _source.time > PlayEpsilon && _source.time < _source.clip.length - 0.1f)
                {
                    Debug.Log($"[Wait] WaitAudioEnd in progress: {_source.time} < {_source.clip.length - 0.1f}");

                    await UniTask.Yield(cancellation);
                }
                
                Debug.Log($"[Wait] WaitAudioEnd completed: {_source.time} < {_source.clip.length - 0.1f}, " +
                          $"!= null: {_source.clip != null}, " +
                          $"isPlaying: {_source.isPlaying}, " +
                          $"time > 0.1: {_source.time > 0.01f}");
            }
        }

        public void Reset()
        {
            _source.Stop();
            _source.clip = null;
        }

        private float GetTime()
        {
            if (_source.clip == null)
                return 0f;
            
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