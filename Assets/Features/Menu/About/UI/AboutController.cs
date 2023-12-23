using System.Threading;
using Cysharp.Threading.Tasks;
using Menu.StateMachine.Definitions;
using UnityEngine;

namespace Menu.About.UI
{
    public class AboutController : IAboutController, ITab
    {
        public AboutController(IAboutView view)
        {
            _view = view;
        }

        private readonly IAboutView _view;

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