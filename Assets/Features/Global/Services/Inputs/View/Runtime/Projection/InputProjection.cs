﻿using Global.Cameras.CameraUtilities.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Inputs.View.Runtime.Projection
{
    public class InputProjection : IInputProjection
    {
        public InputProjection(ICameraUtils cameraUtils)
        {
            _cameraUtils = cameraUtils;
        }

        private readonly ICameraUtils _cameraUtils;
        
        public float GetAngleFrom(Vector2 from)
        {
            var direction = GetDirectionFrom(from);

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (angle < 0f)
                angle += 360f;

            return angle;
        }

        public Vector2 GetDirectionFrom(Vector2 from)
        {
            var screenPosition = Mouse.current.position.ReadValue();
            var worldPosition = _cameraUtils.ScreenToWorld(screenPosition);

            var direction = worldPosition - from;
            direction.Normalize();

            return direction;
        }

        public LineResult GetLineFrom(Vector2 from)
        {
            var screenPosition = Mouse.current.position.ReadValue();
            var worldPosition = _cameraUtils.ScreenToWorld(screenPosition);

            var direction = worldPosition - from;
            direction.Normalize();

            var length = Vector2.Distance(from, worldPosition);

            return new LineResult(direction, length);
        }
    }
}