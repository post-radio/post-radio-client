using Common.UniversalAnimators.Animations.FrameSequence;

namespace Common.UniversalAnimators.Animations.Abstract
{
    public interface IFrameProvider
    {
        int FramesCount { get; }
        IFrameData GetFrame(int index);
    }
}