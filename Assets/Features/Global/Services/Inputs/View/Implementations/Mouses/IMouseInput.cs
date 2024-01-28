using System;
using System.Threading;
using Common.DataTypes.Structs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Mouses
{
    public interface IMouseInput
    {
        event Action LeftDown;
        event Action LeftUp;
        event Action RightDown;
        event Action RightUp;
        event Action<Vertical> Scroll;

        Vector2 Position { get; }
        bool IsWheelPressed { get; }

        UniTask WaitLeftDownAsync(CancellationToken cancellation);
        Vector2 GetWorldPoint();
    }
}