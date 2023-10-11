﻿using System;
using UnityEngine;

namespace UniRx.Operators
{
    internal class FrameIntervalObservable<T> : OperatorObservableBase<FrameInterval<T>>
    {
        readonly IObservable<T> source;

        public FrameIntervalObservable(IObservable<T> source)
            : base(source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
        }

        protected override IDisposable SubscribeCore(IObserver<FrameInterval<T>> observer, IDisposable cancel)
        {
            return source.Subscribe(new FrameInterval(observer, cancel));
        }

        class FrameInterval : OperatorObserverBase<T, FrameInterval<T>>
        {
            int lastFrame;

            public FrameInterval(IObserver<FrameInterval<T>> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                this.lastFrame = Time.frameCount;
            }

            public override void OnNext(T value)
            {
                var now = Time.frameCount;
                var span = now - lastFrame;
                lastFrame = now;

                base.observer.OnNext(new FrameInterval<T>(value, span));
            }

            public override void OnError(Exception error)
            {
                try { observer.OnError(error); }
                finally { Dispose(); }
            }

            public override void OnCompleted()
            {
                try { observer.OnCompleted(); }
                finally { Dispose(); }
            }
        }
    }
}