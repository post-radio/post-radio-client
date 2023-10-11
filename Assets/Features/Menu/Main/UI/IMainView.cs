using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.Main.UI
{
    public interface IMainView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}