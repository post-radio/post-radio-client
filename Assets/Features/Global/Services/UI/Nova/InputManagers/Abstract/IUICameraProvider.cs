using UnityEngine;

namespace Global.UI.Nova.InputManagers.Abstract
{
    public interface IUICameraProvider
    {
        Camera CurrentCamera { get; }
    }
}