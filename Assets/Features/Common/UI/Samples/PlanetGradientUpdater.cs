using System;
using MPUIKIT;
using UnityEngine;

namespace Common.UI.Samples
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MPImage))]
    public class PlanetGradientUpdater : MonoBehaviour
    {
        [SerializeField] private int _fromIndex = 0;
        [SerializeField] private int _toIndex = 3;

        [SerializeField] [Min(0f)] private float _speed;

        private PlanetStage _stage = PlanetStage.Raise;

        private float _progress;

        private Color _start;
        private Color _end;

        private MPImage _image;

        private void Awake()
        {
            _image = GetComponent<MPImage>();
            _start = _image.GradientEffect.CornerGradientColors[_fromIndex];
            _end = _image.GradientEffect.CornerGradientColors[_toIndex];
        }

        private void Update()
        {
            _progress += Time.deltaTime * _speed;

            if (_progress > 1f)
            {
                _progress = 0f;
                _stage = GetNext(_stage);
            }

            float fromProgress;
            float toProgress;

            switch (_stage)
            {
                case PlanetStage.Raise_0:
                    fromProgress = 0f;
                    toProgress = _progress;
                    break;
                case PlanetStage.Raise:
                    fromProgress = _progress;
                    toProgress = 1f;
                    break;
                case PlanetStage.Sunset:
                    fromProgress = 1f;
                    toProgress = 1f - _progress;
                    break;
                case PlanetStage.Over:
                    fromProgress = 1f - _progress;
                    toProgress = 0f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var from = Color.Lerp(_start, _end, fromProgress);
            var to = Color.Lerp(_start, _end, toProgress);

            _image.GradientEffect.CornerGradientColors[0] = from;
            _image.GradientEffect.CornerGradientColors[1] = from;
            _image.GradientEffect.CornerGradientColors[2] = from;
            _image.GradientEffect.CornerGradientColors[3] = to;
            _image.SetMaterialDirty();
        }

        private PlanetStage GetNext(PlanetStage stage)
        {
            return stage switch
            {
                PlanetStage.Raise_0 => PlanetStage.Raise,
                PlanetStage.Raise => PlanetStage.Sunset,
                PlanetStage.Sunset => PlanetStage.Over,
                PlanetStage.Over => PlanetStage.Raise_0,
                _ => throw new ArgumentOutOfRangeException(nameof(stage), stage, null)
            };
        }

        public enum PlanetStage
        {
            Raise_0,
            Raise,
            Sunset,
            Over
        }
    }
}