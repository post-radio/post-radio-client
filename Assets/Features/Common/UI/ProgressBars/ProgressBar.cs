using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UI.ProgressBars
{
    [DisallowMultipleComponent]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _speed = 1f;
        [SerializeField] private RectTransform _transform;
        
        private float _startX;
        
        private void Awake()
        {
            _startX = _transform.offsetMax.x;
        }

        private void OnDisable()
        {
            var offset = _transform.offsetMax;
            offset.x = _startX;
            _transform.offsetMax = offset;
        }

        public async UniTask UpdateProgress(float targetProgress, CancellationToken cancellation)
        {
            var progress = 0f;
            var targetX = _startX - _startX * targetProgress;
            while (progress < 1f && cancellation.IsCancellationRequested == false)
            {
                progress += Time.deltaTime * _speed;
                
                var offset = _transform.offsetMax;
                offset.x = Mathf.Lerp(_startX, targetX, progress);
                _transform.offsetMax = offset;
                
                await UniTask.Yield();
            }
        }
    }
}