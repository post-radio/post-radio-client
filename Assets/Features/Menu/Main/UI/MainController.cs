using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.Main.UI
{
    public class MainController : IMainController, ITab
    {
        public MainController(IMainView view)
        {
            _view = view;
        }

        private readonly IMainView _view;

        public RectTransform Transform => _view.Transform;
        
        public async UniTask Activate(CancellationToken cancellation)
        {
            _view.Navigation.Enable();
        }

        public void Deactivate()
        {
            _view.Navigation.Disable();
        }
    }
}