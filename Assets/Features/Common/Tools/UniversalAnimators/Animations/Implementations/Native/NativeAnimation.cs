﻿using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Animations.Implementations.Native
{
    public class NativeAnimation : IAsyncAnimation
    {
        public NativeAnimation(AnimationData data)
        {
            _data = data;
        }
        
        private readonly AnimationData _data;
        
        public AnimationData Data => _data;

        public Sprite Update(float delta)
        {
            return null;
        }

        public UniTask Play(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}