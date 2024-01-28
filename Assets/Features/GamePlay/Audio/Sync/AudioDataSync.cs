using System;
using Common.DataTypes.Network;
using GamePlay.Audio.Definitions;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Audio.Sync
{
    public class CurrentAudioDataSync : RagonProperty
    {
        public CurrentAudioDataSync() : base(0, false)
        {
            RandomInt = new NetworkInt(0, 10000, 0);
        }
        
        private AudioData _value;
        public readonly NetworkInt RandomInt;

        public AudioData Value => _value;

        public event Action Received;

        public override void Serialize(RagonBuffer buffer)
        {
            _value.Serialize(buffer);
            RandomInt.Serialize(buffer);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _value = AudioData.Deserialize(buffer);
            RandomInt.Deserialize(buffer);
            
            Received?.Invoke();
        }

        public void SetAudio(AudioData audioData, int randomInt)
        {
            _value = audioData;
            RandomInt.Value = randomInt;
            
            MarkAsChanged();
        }
    }
    
    public class NextAudioDataSync : RagonProperty
    {
        public NextAudioDataSync() : base(0, false)
        {
        }
        
        private AudioData _value;

        public AudioData Value => _value;
        public event Action Received;

        public override void Serialize(RagonBuffer buffer)
        {
            _value.Serialize(buffer);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _value = AudioData.Deserialize(buffer);
            Received?.Invoke();
        }

        public void SetAudio(AudioData audioData)
        {
            _value = audioData;
            MarkAsChanged();
        }
    }
}