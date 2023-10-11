using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Menu.Common.Pages
{
    public class PagesContainer
    {
        public PagesContainer(
            IReadOnlyList<IPage> pages,
            IPagesSwitchInvoker switchInvoker)
        {
            _pages = pages;
            _switchInvoker = switchInvoker;
        }

        private int _currentIndex;

        private readonly IReadOnlyList<IPage> _pages;
        private readonly IPagesSwitchInvoker _switchInvoker;

        private IPage _current;
        private CancellationTokenSource _switchCancellation;

        public void Enable()
        {
            _switchInvoker.Enable();
            _currentIndex = 0;

            _switchInvoker.NextRequested += OnNext;
            _switchInvoker.PreviousRequested += OnPrevious;
            
            _switchInvoker.DisablePrevious();

            foreach (var page in _pages)
                page.DeactivateIndex();

            Switch(null, _pages.First()).Forget();
        }

        public void Disable()
        {
            _current = null;

            _switchInvoker.Disable();

            _switchInvoker.NextRequested += OnNext;
            _switchInvoker.PreviousRequested += OnPrevious;

            _switchCancellation?.Cancel();
            _switchCancellation?.Dispose();
            _switchCancellation = null;
        }

        private void OnNext()
        {
            _currentIndex++;

            _switchInvoker.EnablePrevious();

            if (_currentIndex == _pages.Count - 1)
                _switchInvoker.DisableNext();

            Switch(_current, _pages[_currentIndex]).Forget();
        }

        private void OnPrevious()
        {
            _currentIndex--;

            _switchInvoker.EnableNext();

            if (_currentIndex == 0)
                _switchInvoker.DisablePrevious();

            Switch(_current, _pages[_currentIndex]).Forget();
        }

        private async UniTask Switch(IPage previous, IPage next)
        {
            _switchCancellation?.Cancel();
            _switchCancellation?.Dispose();
            _switchCancellation = new CancellationTokenSource();

            _current = next;
            next.ActivateIndex();
            
            if (previous != null)
            {
                previous.DeactivateIndex();
                await previous.Hide(_switchCancellation.Token);
            }

            await next.Show(_switchCancellation.Token);
        }
    }
}