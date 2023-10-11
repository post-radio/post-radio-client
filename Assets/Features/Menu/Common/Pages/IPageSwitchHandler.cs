using Cysharp.Threading.Tasks;

namespace Menu.Common.Pages
{
    public interface IPageSwitchHandler<T>
    {
        void Show(IPage page);
        UniTask Switch(IPage previous, IPage next);
    }
}