using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Global.Inputs.Common;
using Global.Inputs.Constranits.Runtime;
using Global.Inputs.Utils.Runtime;
using Global.Inputs.View.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "InputCompose", menuName = InputRoutes.Root + "Compose")]
    public class InputCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] [Indent] private InputConstraintsFactory _constraints;
        [SerializeField] [Indent] private InputUtilsFactory _utils;
        [SerializeField] [Indent] private InputViewFactory _view;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _constraints,
            _utils,
            _view
        };
    }
}