using Ragon.Client.Compressor;
using Ragon.Protocol;
using UnityEngine;

namespace Common.Network
{
    public static class RagonBufferExtensions
    {
        private const float _delta = 1024f;
        private const float _precision = 0.01f;

        private static readonly FloatCompressor _floatCompressor = new(-1024f, 1024f, 0.01f);
        
        private const float _positionPrecision = 0.01f;
        private const float _minPosition = -1024f;
        private const float _maxPosition = 1024f;
        
        public static readonly FloatCompressor PositionCompressor = new(_minPosition, _maxPosition, _positionPrecision);

        private const float _directionPrecision = 0.001f;
        private static readonly FloatCompressor _directionCompressor = new(-1f, 1f, _directionPrecision);

        
        public static int GetVectorRequiredBits()
        {
            return PositionCompressor.RequiredBits * 2;
        }
        
        public static void WriteVector(this RagonBuffer buffer, Vector2 position)
        {
            var compressedX = _floatCompressor.Compress(position.x);
            var compressedY = _floatCompressor.Compress(position.y);

            buffer.Write(compressedX, _floatCompressor.RequiredBits);
            buffer.Write(compressedY, _floatCompressor.RequiredBits);
        }
        
        public static Vector2 ReadVector(this RagonBuffer buffer)
        {
            var compressedX = buffer.Read(_floatCompressor.RequiredBits);
            var compressedY = buffer.Read(_floatCompressor.RequiredBits);

            var x = _floatCompressor.Decompress(compressedX);
            var y = _floatCompressor.Decompress(compressedY);
            
            return new Vector2(x, y);
        }
        
        public static void WritePosition(this RagonBuffer buffer, Vector2 position)
        {
            var compressedX = PositionCompressor.Compress(position.x);
            var compressedY = PositionCompressor.Compress(position.y);

            buffer.Write(compressedX, PositionCompressor.RequiredBits);
            buffer.Write(compressedY, PositionCompressor.RequiredBits);
        }
        
        public static Vector2 ReadPosition(this RagonBuffer buffer)
        {
            var compressedX = buffer.Read(PositionCompressor.RequiredBits);
            var compressedY = buffer.Read(PositionCompressor.RequiredBits);

            var x = PositionCompressor.Decompress(compressedX);
            var y = PositionCompressor.Decompress(compressedY);
            
            return new Vector2(x, y);
        }
        
        public static void WriteDirection(this RagonBuffer buffer, Vector2 direction)
        {
            var compressedX = _directionCompressor.Compress(direction.x);
            var compressedY = _directionCompressor.Compress(direction.y);

            buffer.Write(compressedX, _directionCompressor.RequiredBits);
            buffer.Write(compressedY, _directionCompressor.RequiredBits);
        }
        
        public static Vector2 ReadDirection(this RagonBuffer direction)
        {
            var compressedX = direction.Read(_directionCompressor.RequiredBits);
            var compressedY = direction.Read(_directionCompressor.RequiredBits);

            var x = _directionCompressor.Decompress(compressedX);
            var y = _directionCompressor.Decompress(compressedY);
            
            return new Vector2(x, y);
        }
    }
}