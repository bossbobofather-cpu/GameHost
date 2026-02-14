using System;
using System.Buffers;

namespace Noname.GameHost
{
    /// <summary>
    /// ArrayPool에서 대여한 버퍼와 유효 길이를 담는 구조체입니다.
    /// </summary>
    public readonly struct PooledSegment : IDisposable
    {
        /// <summary>
        /// 대여한 원본 버퍼입니다.
        /// </summary>
        public readonly byte[] Buffer;

        /// <summary>
        /// 버퍼에서 실제로 유효한 데이터 길이입니다.
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// 풀 버퍼 세그먼트를 생성합니다.
        /// </summary>
        /// <param name="buffer">대여한 버퍼입니다.</param>
        /// <param name="length">유효 데이터 길이입니다.</param>
        public PooledSegment(byte[] buffer, int length)
        {
            Buffer = buffer;
            Length = length;
        }

        /// <summary>
        /// 전송/복사에 사용하기 쉬운 <see cref="ArraySegment{T}"/> 형태로 반환합니다.
        /// </summary>
        public ArraySegment<byte> Segment => new(Buffer, 0, Length);

        /// <summary>
        /// 대여한 버퍼를 ArrayPool에 반환합니다.
        /// </summary>
        public void Dispose()
        {
            if (Buffer != null)
            {
                ArrayPool<byte>.Shared.Return(Buffer);
            }
        }
    }
}
