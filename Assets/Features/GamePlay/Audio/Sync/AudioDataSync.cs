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
        
        private StoredAudio _value;
        public readonly NetworkInt RandomInt;

        public StoredAudio Value => _value;

        public event Action Received;

        public override void Serialize(RagonBuffer buffer)
        {
            _value.Serialize(buffer);
            RandomInt.Serialize(buffer);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _value = StoredAudio.Deserialize(buffer);
            RandomInt.Deserialize(buffer);
            
            Received?.Invoke();
        }

        public void SetAudio(StoredAudio audio, int randomInt)
        {
            _value = audio;
            RandomInt.Value = randomInt;
            
            MarkAsChanged();
        }
    }
    
    public class NextAudioDataSync : RagonProperty
    {
        public NextAudioDataSync() : base(0, false)
        {
        }
        
        private StoredAudio _value;

        public StoredAudio Value => _value;
        public event Action Received;

        public override void Serialize(RagonBuffer buffer)
        {
            _value.Serialize(buffer);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _value = StoredAudio.Deserialize(buffer);
            Received?.Invoke();
        }

        public void SetAudio(StoredAudio audio)
        {
            _value = audio;
            MarkAsChanged();
        }
    }
}