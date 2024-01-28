using UnityEngine;

namespace Global.Cameras.Persistent.Runtime
{
    public interface IGlobalCamera
    {
        Camera Camera { get; }
        void Enable();
        void Disable();
    }
}