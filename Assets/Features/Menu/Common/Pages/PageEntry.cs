using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Menu.Common.Pages
{
    public abstract class PageEntry<T> : MonoBehaviour
    {
        public abstract UniTask Show(T value, CancellationToken cancellation);
        public abstract UniTask Hide(CancellationToken cancellation);
    }
}