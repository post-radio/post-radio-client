using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Menu.Common.Pages
{
    public class Page<T> : IPage
    {
        public Page(
            IReadOnlyList<T> values,
            IReadOnlyList<PageEntry<T>> entries,
            IPageIndexView indexView,
            PagesSwitchConfiguration configuration)
        {
            _values = values;
            _entries = entries;
            _indexView = indexView;
            _configuration = configuration;
        }

        private readonly IReadOnlyList<T> _values;
        private readonly IReadOnlyList<PageEntry<T>> _entries;
        private readonly IPageIndexView _indexView;
        private readonly PagesSwitchConfiguration _configuration;

        public void ActivateIndex()
        {
            _indexView.Activate();
        }

        public void DeactivateIndex()
        {
            _indexView.Deactivate();
        }

        public async UniTask Show(CancellationToken cancellation)
        {
            var tasks = new UniTask[_values.Count];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = _entries[i].Show(_values[i], cancellation);

                if (_configuration != null)
                    await UniTask.Delay(_configuration.ElementSwitchDelay, cancellation);
            }

            await UniTask.WhenAll(tasks);
        }

        public async UniTask Hide(CancellationToken cancellation)
        {
            var tasks = new UniTask[_entries.Count];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = _entries[i].Hide(cancellation);
                
                if (_configuration != null)
                    await UniTask.Delay(_configuration.ElementSwitchDelay, cancellation);
            }

            await UniTask.WhenAll(tasks);
        }
    }
}