using UnityEngine;

namespace GamePlay.Audio.UI.Overlay
{
    [DisallowMultipleComponent]
    public class AudioProgressBar : MonoBehaviour, IAudioProgressBar
    {
        [SerializeField] private RectTransform _transform;

        private float _startX;

        private void Awake()
        {
            _startX = _transform.anchoredPosition.x;
        }

        public void UpdateProgress(float targetProgress)
        {
            var position = _transform.anchoredPosition;
            position.x = _startX + _transform.sizeDelta.x * targetProgress;
            _transform.anchoredPosition = position;
        }
    }
}