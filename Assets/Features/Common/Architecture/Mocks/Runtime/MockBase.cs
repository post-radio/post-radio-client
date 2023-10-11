using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Architecture.Mocks.Runtime
{
    [DisallowMultipleComponent]
    public abstract class MockBase : MonoBehaviour
    {
        public abstract UniTaskVoid Process();
    }
}