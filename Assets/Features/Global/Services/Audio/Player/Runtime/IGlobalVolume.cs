﻿using System;

namespace Global.Audio.Player.Runtime
{
    public interface IGlobalVolume
    {
        float Music { get; }
        float Sound { get; }

        event Action VolumeUpdated;
        
        void Mute();
        void Unmute();

        void SaveVolume();
        void SetVolume(float music, float sound);
    }
}