using System.Collections.Generic;

namespace Tools.AutoShorts.Runtime.SlideShow
{
    public interface ISlideShow
    {
        void Play(SlideShowOptions options, IReadOnlyList<SlideData> slides);
    }
}