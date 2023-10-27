using System;
using UnityEngine;

namespace GamePlay.Loop.Runtime
{
    [Serializable]
    public class TransitToGameConfig
    {
        [SerializeField] private float _time;
        [SerializeField] private float _startCameraScale;
        [SerializeField] private float _targetCameraScale;

        public float Time => _time;
        public float StartCameraScale => _startCameraScale;
        public float TargetCameraScale => _targetCameraScale;
    }
}