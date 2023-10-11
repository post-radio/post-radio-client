using UnityEngine;

namespace Menu.Common.Pages
{
    [DisallowMultipleComponent]
    public class PageIndexView : MonoBehaviour, IPageIndexView
    {
        [SerializeField] private GameObject _active;
        [SerializeField] private GameObject _inactive;

        public void Activate()
        {
            _active.SetActive(true);
            _inactive.SetActive(false);
        }
        
        public void Deactivate()
        {
            _active.SetActive(false);
            _inactive.SetActive(true);
        }
    }
}