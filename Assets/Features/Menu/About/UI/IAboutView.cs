using Menu.Common.Navigation;
using UnityEngine;

namespace Menu.About.UI
{
    public interface IAboutView
    {
        ITabNavigation Navigation { get; }
        RectTransform Transform { get; }
    }
}