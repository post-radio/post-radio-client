using UnityEngine;

namespace Tools.AutoShorts.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class ShortsPlayer : MonoBehaviour, IShortsPlayer
    {
        public void Play(AudioClip clip, float start)
        {
            var source = GetComponent<AudioSource>();
            source.clip = clip;
            source.time = start;
            source.Play();
        }
    }
}