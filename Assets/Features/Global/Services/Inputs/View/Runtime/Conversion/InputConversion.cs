﻿using Global.Cameras.CameraUtilities.Runtime;
using UnityEngine;

namespace Global.Inputs.View.Runtime.Conversion
{
    public class InputConversion : IInputConversion
    {
        public InputConversion(ICameraUtils cameraUtils)
        {
            _cameraUtils = cameraUtils;
        }
        
        private readonly ICameraUtils _cameraUtils;

        public Vector2 ScreenToWorld(Vector2 position)
        {
            var worldPosition = _cameraUtils.ScreenToWorld(position);

            Debug.Log($"Raw: {position}, world: {worldPosition}");

            return worldPosition;
        }
    }
}