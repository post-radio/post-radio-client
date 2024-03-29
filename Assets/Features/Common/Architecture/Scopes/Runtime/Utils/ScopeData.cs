﻿using VContainer.Unity;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public class ScopeData : IScopeData
    {
        public ScopeData(LifetimeScope scope)
        {
            _scope = scope;
        }

        private readonly LifetimeScope _scope;

        public LifetimeScope Scope => _scope;
    }
}