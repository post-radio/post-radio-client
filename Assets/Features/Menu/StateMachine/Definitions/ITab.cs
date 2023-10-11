using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Menu.StateMachine.Definitions
{
    public interface ITab
    {
        RectTransform Transform { get; }

        UniTask Activate(CancellationToken cancellation);
        void Deactivate();
    }
}