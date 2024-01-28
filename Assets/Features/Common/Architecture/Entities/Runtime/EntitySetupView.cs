using Common.Architecture.Container.Abstract;
using UnityEngine;
using VContainer.Unity;

namespace Common.Architecture.Entities.Runtime
{
    public abstract class EntitySetupView : MonoBehaviour, IEntityViewFactory
    {
        [SerializeField] private LifetimeScope _scope;

        public LifetimeScope Scope => _scope;

        public abstract void CreateViews(IServiceCollection services, IEntityUtils utils);
    }
}