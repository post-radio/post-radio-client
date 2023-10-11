using UnityEngine;
using UnityEngine.Splines;

namespace Common.UI.Samples
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class StarView : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _speed;
        [SerializeField] [Min(0f)] private float _maxSize;

        [SerializeField] private Transform _sun;
        [SerializeField] private SplineContainer _spline;

        private float _progress;

        private void Awake()
        {
            _progress = transform.GetSiblingIndex() / (float)transform.parent.childCount;
            _maxSize *= Random.Range(0.5f, 1.5f);
        }

        private void Update()
        {
            _progress += Time.deltaTime * _speed;

            if (_progress > 1f)
                _progress = 0f;

            var position = _spline.EvaluatePosition(_progress);
            var currentPosition = transform.position;
            currentPosition.x = position.x;
            currentPosition.y = position.y;
            transform.position = currentPosition;
            transform.localScale = Vector3.one * (Mathf.Sin(Mathf.PI * _progress) * _maxSize);

            if (currentPosition.y > _sun.position.y)
                transform.SetAsFirstSibling();
            else
                transform.SetAsLastSibling();
        }
    }
}