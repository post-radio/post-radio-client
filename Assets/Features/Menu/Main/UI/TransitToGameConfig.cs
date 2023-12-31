﻿using System;
using UnityEngine;

namespace Menu.Main.UI
{
    [Serializable]
    public class TransitToGameConfig
    {
        [SerializeField] private float _time;
        [SerializeField] private float _targetCameraScale;
        [SerializeField] private float _baseCameraScale;

        public float Time => _time;
        public float TargetCameraScale => _targetCameraScale;
        public float BaseCameraScale => _baseCameraScale;
    }
}