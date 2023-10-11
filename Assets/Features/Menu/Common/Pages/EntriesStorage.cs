using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menu.Common.Pages
{
    [Serializable]
    public class EntriesStorage<T, T1> : IEntriesStorage<T, T1> where T : PageEntry<T1>
    {
        [SerializeField] private T[] _entries;

        public IReadOnlyList<T> Entries => _entries;
    }
}