using Global.UI.Nova.InputManagers.Abstract;
using Nova;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Global.UI.Nova.InputManagers.Runtime
{
    public class TouchInputHandler
    {
        public TouchInputHandler(IUICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }
        
        private readonly IUICameraProvider _cameraProvider;
        
        public void UpdateTouch()
        {
            var touchCount = Touch.activeTouches.Count;
            
            for (var i = 0; i < touchCount; i++)
            {
                var touch = Touch.activeTouches[i];
                var ray = _cameraProvider.CurrentCamera.ScreenPointToRay(touch.screenPosition);
                
                var touchId = (uint)touch.finger.index;
                var update = new Interaction.Update(ray, touchId);
                
                var touchPhase = touch.phase;
                var pointerDown = touchPhase != TouchPhase.Canceled && touchPhase != TouchPhase.Ended;
                
                Interaction.Point(update, pointerDown);

                if (pointerDown == false)
                {
                    update.Ray = default;
                    Interaction.Point(update, false);
                    Interaction.Cancel(update);
                }
            }
        }
    }
}