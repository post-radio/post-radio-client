using System.Collections.Generic;

namespace Global.Backend.Abstract
{
    public interface IGetRequest
    {
        string Uri { get; }
        IReadOnlyList<IRequestHeader> Headers { get; }
    }
}