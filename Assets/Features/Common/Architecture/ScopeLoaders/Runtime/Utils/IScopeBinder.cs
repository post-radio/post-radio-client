using UnityEngine;

namespace Common.Architecture.ScopeLoaders.Runtime.Utils
{
    public interface IScopeBinder
    {
        void MoveToModules(MonoBehaviour service);
        void MoveToModules(GameObject service);
        void MoveToModules(Transform service);
    }
}