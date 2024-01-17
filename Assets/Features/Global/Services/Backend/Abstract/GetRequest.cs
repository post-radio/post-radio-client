using System.Collections.Generic;

namespace Global.Backend.Abstract
{
    public class GetRequest : IGetRequest
    {
        public GetRequest(string url, IReadOnlyList<IRequestHeader> headers)
        {
            Uri = url;
            Headers = headers;
        }

        public string Uri { get; }
        public IReadOnlyList<IRequestHeader> Headers { get; }
    }
}