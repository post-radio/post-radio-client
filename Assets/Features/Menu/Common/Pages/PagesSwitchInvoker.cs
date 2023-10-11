using System;
using Common.UI.Buttons;
using UnityEngine;

namespace Menu.Common.Pages
{
    [Serializable]
    public class PagesSwitchInvoker : IPagesSwitchInvoker
    {
        [SerializeField] private ExtendedButton _previousButton;
        [SerializeField] private ExtendedButton _nextButton;
        
        public event Action PreviousRequested;
        public event Action NextRequested;

        public void Enable()
        {
            _previousButton.Clicked += OnPreviousClicked;
            _nextButton.Clicked += OnNextClicked;
        }

        public void Disable()
        {
            _previousButton.Clicked -= OnPreviousClicked;
            _nextButton.Clicked -= OnNextClicked;
        }

        public void EnablePrevious()
        {
            _previousButton.gameObject.SetActive(true);
        }

        public void DisablePrevious()
        {
            _previousButton.gameObject.SetActive(false);
        }

        public void EnableNext()
        {
            _nextButton.gameObject.SetActive(true);
        }

        public void DisableNext()
        {
            _nextButton.gameObject.SetActive(false);
        }
        
        private void OnNextClicked()
        {
            NextRequested?.Invoke();
        }

        private void OnPreviousClicked()
        {
            PreviousRequested?.Invoke();
        }
    }
}