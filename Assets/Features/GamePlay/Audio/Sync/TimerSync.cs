using Common.DataTypes.Network;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Audio.Sync
{
    public class TimerSync : RagonProperty
    {
        public TimerSync() : base(0, false)
        {
            Time = new NetworkFloat(0, 10000, 0.01f, 0f);
            RandomInt = new NetworkInt(0, 10000, 0);
        }

        private bool _isDirty;
        
        public readonly NetworkFloat Time;
        public readonly NetworkInt RandomInt;
        public bool IsDitry => !(_isDirty == true && Mathf.Approximately(Time.Value, 0f));    

        public void SetTime(float time, int randomInt)
        {
            Time.SetValue(time);
            RandomInt.Value = randomInt;
            _isDirty = true;
            MarkAsChanged();
        }
        
        public override void Serialize(RagonBuffer buffer)
        {
            Time.Serialize(buffer);
            RandomInt.Serialize(buffer);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            Time.Deserialize(buffer);
            RandomInt.Deserialize(buffer);
            _isDirty = false;
        }
    }
}