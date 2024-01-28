using UnityEngine;

namespace Common.Architecture.Scopes.Runtime.Utils
{
    public interface IScopeBinder
    {
        void MoveToModules(MonoBehaviour service);
        void MoveToModules(GameObject service);
        void MoveToModules(Transform service);
    }
}