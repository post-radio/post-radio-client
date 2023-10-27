﻿using UnityEngine;

namespace Common.Architecture.DiContainer.Abstract
{
    public interface IServiceCollection
    {
        IRegistration Register<T>();
        IRegistration RegisterInstance<T>(T instance);
        IRegistration RegisterComponent<T>(T component) where T : Object;
        void Inject<T>(T component);
    }
}