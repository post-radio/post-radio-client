using System;
using Features.Global.Services.Publisher.Abstract.Callbacks;
using UnityEngine;

namespace Global.Publisher.Itch.Common
{
    [DisallowMultipleComponent]
    public class WebCallbacks : MonoBehaviour, IJsErrorCallback
    {
        public event Action<string> Exception; 
        
        public void OnException(string exception)
        {
            Exception?.Invoke(exception);
        }
    }
}