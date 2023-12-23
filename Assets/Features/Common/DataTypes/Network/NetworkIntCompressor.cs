using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace Common.DataTypes.Network
{
    public class NetworkIntCompressor
    {
        public NetworkIntCompressor(int min, int max)
        {
            _compressor = new IntCompressor(min, max);
        }

        private readonly IntCompressor _compressor;

        public void Write(RagonBuffer buffer, int value)
        {
            var compressed = _compressor.Compress(value);
            buffer.Write(compressed, _compressor.RequiredBits);
        }
        
        public int Read(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            var value = _compressor.Decompress(compressed);

            return value;
        }
    }
}