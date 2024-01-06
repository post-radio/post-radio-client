using Common.DataTypes.Network;
using Ragon.Client;
using Ragon.Protocol;

namespace GamePlay.Audio.Sync
{
    public class TimerSync : RagonProperty
    {
        public TimerSync() : base(0, false)
        {
            Time = new NetworkFloat(0, 10000, 0.01f, 0f);
            RandomInt = new NetworkInt(0, 10000, 0);
        }

        public readonly NetworkFloat Time;
        public readonly NetworkInt RandomInt;

        private float _timeValue;
        private int _randomIntValue;

        public float TimeValue => _timeValue;
        public int RandomIntValue => _randomIntValue;

        public void SetTime(float time, int randomInt)
        {
            Time.SetValue(time);
            RandomInt.Value = randomInt;
            
            _timeValue = -1f;
            _randomIntValue = -1;
            
            MarkAsChanged();
        }

        public void MarkChanged(float time, int randomInt)
        {
            Time.SetValue(time);
            RandomInt.Value = randomInt;

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
            _timeValue = Time.Value;
            _randomIntValue = RandomInt.Value;  
        }
    }
}