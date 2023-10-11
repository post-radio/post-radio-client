using System.Collections.Generic;

namespace Menu.Common.Pages
{
    public interface IEntriesStorage<T, T1> where T : PageEntry<T1> 
    {
        IReadOnlyList<T> Entries { get; }
    }
}