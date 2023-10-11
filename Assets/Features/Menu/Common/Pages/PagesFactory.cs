using System.Collections.Generic;
using UnityEngine;

namespace Menu.Common.Pages
{
    public class PagesFactory<T, T1> where T : PageEntry<T1> 
    {
        public PagesFactory(
            IEntriesStorage<T, T1> entriesStorage, 
            IPageIndexViewFactory indexViewFactory,
            PagesSwitchConfiguration configuration = null)
        {
            _entriesStorage = entriesStorage;
            _indexViewFactory = indexViewFactory;
            _configuration = configuration;
        }
        
        private readonly IEntriesStorage<T, T1> _entriesStorage;
        private readonly IPageIndexViewFactory _indexViewFactory;
        private readonly PagesSwitchConfiguration _configuration;

        public IReadOnlyList<IPage> Create(IReadOnlyList<T1> values)
        {
            var pages = new List<IPage>();
            var entries = _entriesStorage.Entries;
            var pagesCount = Mathf.CeilToInt(values.Count / (float)entries.Count);

            for (var i = 0; i < pagesCount; i++)
            {
                var start = i * entries.Count;
                var pageValues = new List<T1>();
                var pageEntries = new List<T>();
                var counter = 0;

                while (counter < entries.Count && start + counter < values.Count)
                {
                    var index = start + counter;
                    pageValues.Add(values[index]);
                    pageEntries.Add(entries[counter]);
                    counter++;
                }

                var pageIndex = _indexViewFactory.Create();
                var page = new Page<T1>(pageValues, pageEntries, pageIndex, _configuration);
                pages.Add(page);
            }

            return pages;
        }
    }
}