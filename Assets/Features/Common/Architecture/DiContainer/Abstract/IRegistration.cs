﻿using System;

namespace Common.Architecture.DiContainer.Abstract
{
    public interface IRegistration
    {
        Type Type { get; }
        IServiceCollection Builder { get; }
        
        IRegistration AsCallbackListener();
        IRegistration AsSelf();
        IRegistration AsImplementedInterfaces();
        IRegistration AsSelfResolvable();
        IRegistration As<T>();
        IRegistration WithParameter<T>(T value);
    }
}