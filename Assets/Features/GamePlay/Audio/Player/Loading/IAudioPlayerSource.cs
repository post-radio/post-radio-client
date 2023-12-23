using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GamePlay.Audio.Player.Loading
{
    public interface IAudioPlayerSource
    {
        void SetVolume(float volume);
        UniTask Play(AudioClip clip, float delay);
    }
}