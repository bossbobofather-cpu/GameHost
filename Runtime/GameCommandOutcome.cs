using System.Collections.Generic;

namespace Noname.GameHost
{
    /// <summary>
    /// 커맨드 처리 결과를 담는 불변 구조체입니다.
    /// </summary>
    /// <typeparam name="TResult">커맨드 실행 결과 타입입니다.</typeparam>
    /// <typeparam name="TEvent">발행할 이벤트 타입입니다.</typeparam>
    public readonly struct GameCommandOutcome<TResult, TEvent>
    {
        /// <summary>
        /// 결과 처리 전에 발행할 이벤트 목록입니다.
        /// </summary>
        public IReadOnlyList<TEvent> PreEvents { get; }

        /// <summary>
        /// 커맨드 실행 결과입니다.
        /// </summary>
        public TResult Result { get; }

        /// <summary>
        /// 결과 처리 후에 발행할 이벤트 목록입니다.
        /// </summary>
        public IReadOnlyList<TEvent> PostEvents { get; }

        /// <summary>
        /// 후행 이벤트만 포함하는 결과를 생성합니다.
        /// </summary>
        /// <param name="result">커맨드 실행 결과입니다.</param>
        /// <param name="postEvents">결과 처리 후 발행할 이벤트 목록입니다.</param>
        public GameCommandOutcome(TResult result, IReadOnlyList<TEvent> postEvents = null)
        {
            PreEvents = null;
            Result = result;
            PostEvents = postEvents;
        }

        /// <summary>
        /// 선행/후행 이벤트를 모두 포함하는 결과를 생성합니다.
        /// </summary>
        /// <param name="preEvents">결과 처리 전 발행할 이벤트 목록입니다.</param>
        /// <param name="result">커맨드 실행 결과입니다.</param>
        /// <param name="postEvents">결과 처리 후 발행할 이벤트 목록입니다.</param>
        public GameCommandOutcome(
            IReadOnlyList<TEvent> preEvents,
            TResult result,
            IReadOnlyList<TEvent> postEvents = null)
        {
            PreEvents = preEvents;
            Result = result;
            PostEvents = postEvents;
        }
    }
}
