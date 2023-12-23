using Global.System.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Services.LevelCameras.Runtime
{
    [DisallowMultipleComponent]
    public class CameraMoveBlockerUIObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Msg.Publish(new CameraBlockedEvent());            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Msg.Publish(new CameraUnblockedEvent());            
        }
    }
}