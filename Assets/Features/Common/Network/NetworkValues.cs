using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace Common.Network
{
    public class NetworkInt : IRagonEvent
    {
        public NetworkInt()
        {
        }

        public NetworkInt(int min, int max)
        {
            _compressor = new IntCompressor(min, max);
            Value = 0;
        }
        
        public NetworkInt(int min, int max, int value)
        {
            _compressor = new IntCompressor(min, max);
            Value = value;
        }

        private readonly IntCompressor _compressor;

        public int Value { get; private set; }

        public void Serialize(RagonBuffer buffer)
        {
            var compressed = _compressor.Compress(Value);
            buffer.Write(compressed, _compressor.RequiredBits);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            Value = _compressor.Decompress(compressed);
        }
    }

    public class NetworkFloat : IRagonEvent
    {
        public NetworkFloat()
        {
        }

        public NetworkFloat(float min, float max, float precision, float value)
        {
            _compressor = new FloatCompressor(min, max, precision);
            Value = value;
        }

        private readonly FloatCompressor _compressor;

        public float Value { get; private set; }

        public void Serialize(RagonBuffer buffer)
        {
            var compressed = _compressor.Compress(Value);
            buffer.Write(compressed, _compressor.RequiredBits);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            Value = _compressor.Decompress(compressed);
        }
    }

    public class NetworkString : IRagonEvent
    {
        public NetworkString()
        {
        }

        public NetworkString(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteString(Value);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Value = buffer.ReadString();
        }
    }
    
    public class NetworkBool : IRagonEvent
    {
        public NetworkBool()
        {
        }

        public NetworkBool(bool value)
        {
            Value = value;
        }

        public bool Value { get; private set; }

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteBool(Value);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            Value = buffer.ReadBool();
        }
    }
}