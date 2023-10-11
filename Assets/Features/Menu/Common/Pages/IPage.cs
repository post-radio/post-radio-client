using System.Threading;
using Cysharp.Threading.Tasks;

namespace Menu.Common.Pages
{
    public interface IPage
    {
        void ActivateIndex();
        void DeactivateIndex();
        
        UniTask Show(CancellationToken cancellation);
        UniTask Hide(CancellationToken cancellation);
    }
}