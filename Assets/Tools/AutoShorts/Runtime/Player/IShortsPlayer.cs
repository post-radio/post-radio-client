using UnityEngine;

namespace Tools.AutoShorts.Runtime
{
    public interface IShortsPlayer
    {
        void Play(AudioClip clip, float start);
    }
}