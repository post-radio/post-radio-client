using UnityEngine;

namespace Global.Cameras.CurrentProvider.Runtime
{
    public interface ICurrentCameraProvider
    {
        Camera Current { get; }

        void SetCamera(Camera current);
    }
}