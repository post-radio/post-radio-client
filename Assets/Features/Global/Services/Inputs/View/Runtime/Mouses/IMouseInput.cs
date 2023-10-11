using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Global.Inputs.View.Runtime.Mouses
{
    public interface IMouseInput
    {
        event Action LeftDown;
        event Action LeftUp;
        event Action RightDown;
        event Action RightUp;

        Vector2 Position { get; }

        UniTask WaitLeftDownAsync(CancellationToken cancellation);
        Vector2 GetWorldPoint();
    }
}