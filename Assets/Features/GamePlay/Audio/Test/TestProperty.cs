using Common.DataTypes.Network;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Audio.Test
{
    public class TestProperty : RagonProperty
    {
        public TestProperty() : base(0, true)
        {
            _value = new NetworkString();
        }

        public NetworkString _value;

        public override void Serialize(RagonBuffer buffer)
        {
            _value.Serialize(buffer);
            Debug.Log($"Buffer 1: {buffer.WriteOffset}");
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            Debug.Log($"Buffer 2: {buffer.ReadOffset}");
            _value.Deserialize(buffer);

            Debug.Log(_value.Value);
        }

        public void Update()
        {
            _value.Value = "asdasd";
            MarkAsChanged();
        }
    }
}