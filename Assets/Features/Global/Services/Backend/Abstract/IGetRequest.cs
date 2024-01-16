using System.Collections.Generic;

namespace Global.Services.Backend.Abstract
{
    public interface IGetRequest
    {
        string Uri { get; }
        IReadOnlyList<IRequestHeader> Headers { get; }
    }
}