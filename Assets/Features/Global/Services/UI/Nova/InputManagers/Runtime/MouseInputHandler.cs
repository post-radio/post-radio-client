using System.Collections.Generic;
using Global.UI.Nova.InputManagers.Abstract;
using Global.UI.Nova.InputManagers.Logs;
using Nova;
using Nova.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.UI.Nova.InputManagers.Runtime
{
    public class MouseInputHandler
    {
        public MouseInputHandler(IUICameraProvider cameraProvider, InputManagerLogger logger)
        {
            _cameraProvider = cameraProvider;
            _logger = logger;
        }

        private readonly IUICameraProvider _cameraProvider;
        private readonly InputManagerLogger _logger;
        private readonly List<UIBlockHit> _hitCache = new();

        private const bool _isScrollingInverted = true;
        private const uint MousePointerControlID = 1;
        private const uint ScrollWheelControlID = 2;

        public void UpdateMouse()
        {
            var mouse = Mouse.current;
            var mousePosition = mouse.position.ReadValue();

            var mouseRay = _cameraProvider.CurrentCamera.ScreenPointToRay(mousePosition);
            var mouseScrollDelta = mouse.scroll.ReadValue().normalized;

            _logger.OnMousePosition(mousePosition);
            _logger.OnMouseScroll(mouseScrollDelta);

            if (mouseScrollDelta != Vector2.zero)
            {
                if (_isScrollingInverted)
                    mouseScrollDelta.y *= -1f;

                var scrollInteraction = new Interaction.Update(mouseRay, ScrollWheelControlID);
                Interaction.Scroll(scrollInteraction, mouseScrollDelta);
            }

            var pointInteraction = new Interaction.Update(mouseRay, MousePointerControlID);
            var leftMouseButton = mouse.leftButton;
            var isLeftMouseDown = leftMouseButton.isPressed;

            Interaction.Point(pointInteraction, isLeftMouseDown);

            var isLeftMouseUp = leftMouseButton.wasReleasedThisFrame;

            if (isLeftMouseUp)
                Interaction.TryGetActiveReceiver(MousePointerControlID, out _);

            _logger.OnLeftMouseButton(isLeftMouseDown, isLeftMouseUp);
        }

        public bool IsCollidingLayer(int layerMask)
        {
            _hitCache.Clear();
            var mouse = Mouse.current;
            var mousePosition = mouse.position.ReadValue();

            var mouseRay = _cameraProvider.CurrentCamera.ScreenPointToRay(mousePosition);
            var pointInteraction = new Interaction.Update(mouseRay, MousePointerControlID);
            InteractionType hitTestInteraction = InteractionType.RequiresHit;
            Interaction.GetHits<bool>(pointInteraction, float.PositiveInfinity, layerMask, _hitCache, hitTestInteraction);
            
            if (_hitCache.Count > 0)
                return true;

            return false;
        }
    }
}