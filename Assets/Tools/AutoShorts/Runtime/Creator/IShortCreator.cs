using System.Collections.Generic;
using Tools.AutoShorts.Runtime.SlideShow;

namespace Tools.AutoShorts.Runtime
{
    public interface IShortCreator
    {
        AudioOptions AudioOptions { get; }
        SlideShowOptions SlideShowOptions { get; }
        IReadOnlyList<SlideData> Slides { get; }
    }
}