using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace Common.Network
{
    public class NetworkFloatCompressor
    {
        public NetworkFloatCompressor(float min, float max, float precision)
        {
            _compressor = new FloatCompressor(min, max, precision);
        }

        private readonly FloatCompressor _compressor;

        public void Write(RagonBuffer buffer, float value)
        {
            var compressed = _compressor.Compress(value);
            buffer.Write(compressed, _compressor.RequiredBits);
        }

        public float Read(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            var value = _compressor.Decompress(compressed);

            return value;
        }
    }
}