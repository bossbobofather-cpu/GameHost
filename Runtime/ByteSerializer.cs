using System;
using System.Buffers;

namespace Noname.GameHost
{
    /// <summary>
    /// 바이트 배열로 직렬화할 수 있는 객체의 공통 인터페이스입니다.
    /// </summary>
    public interface IByteSerializable
    {
        /// <summary>
        /// 직렬화에 필요한 총 바이트 크기를 반환합니다.
        /// </summary>
        int GetSerializedSize();

        /// <summary>
        /// 지정한 버퍼에 객체 데이터를 기록합니다.
        /// </summary>
        /// <param name="dst">직렬화 데이터를 기록할 대상 버퍼입니다.</param>
        /// <returns>실제로 기록한 바이트 수입니다.</returns>
        int WriteTo(Span<byte> dst);
    }

    /// <summary>
    /// 바이트 직렬화 유틸리티입니다.
    /// </summary>
    public static class ByteSerializer
    {
        /// <summary>
        /// 객체를 ArrayPool 버퍼에 직렬화하고 세그먼트를 반환합니다.
        /// </summary>
        /// <param name="obj">직렬화할 객체입니다.</param>
        /// <returns>풀 버퍼와 유효 길이를 담은 세그먼트입니다.</returns>
        public static PooledSegment SerializePooled(IByteSerializable obj)
        {
            int size = obj.GetSerializedSize();
            byte[] buffer = ArrayPool<byte>.Shared.Rent(size);

            int written = obj.WriteTo(buffer.AsSpan(0, size));
            if (written != size)
            {
                ArrayPool<byte>.Shared.Return(buffer);
                throw new InvalidOperationException($"Size mismatch. expected={size}, written={written}");
            }

            return new PooledSegment(buffer, written);
        }
    }
}
