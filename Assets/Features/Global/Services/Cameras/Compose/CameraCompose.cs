using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Cameras.Common;
using Global.Cameras.CurrentProvider.Runtime;
using Global.Cameras.Persistent.Runtime;
using Global.Cameras.Utils.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalCameraCompose", menuName = GlobalCameraAssetsPaths.Root + "Compose")]
    public class CameraCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] [Indent] private CurrentCameraProviderFactory _currentProvider;
        [SerializeField] [Indent] private GlobalCameraFactory _global;
        [SerializeField] [Indent] private CameraUtilsFactory _utils;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _currentProvider,
            _global,
            _utils
        };
    }
}