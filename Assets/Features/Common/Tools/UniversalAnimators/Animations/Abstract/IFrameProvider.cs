using Common.Tools.UniversalAnimators.Animations.FrameSequence;

namespace Common.Tools.UniversalAnimators.Animations.Abstract
{
    public interface IFrameProvider
    {
        int FramesCount { get; }
        IFrameData GetFrame(int index);
    }
}