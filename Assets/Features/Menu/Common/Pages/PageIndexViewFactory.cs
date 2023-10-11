using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Menu.Common.Pages
{
    [Serializable]
    public class PageIndexViewFactory : IPageIndexViewFactory
    {
        [SerializeField] private PageIndexView _prefab;
        [SerializeField] private RectTransform _root;

        public IPageIndexView Create()
        {
            var index = Object.Instantiate(_prefab, _root);
            index.transform.SetAsLastSibling();

            return index;
        }
    }
}