using System;

namespace Noname.GameHost.GameEvent
{
    /// <summary>
    /// GameEventBus 사용을 단순화한 파사드 클래스입니다.
    /// </summary>
    public static class GameEventHub
    {
        /// <summary>
        /// 전역 이벤트 버스 스코프입니다.
        /// </summary>
        public static GameEventBus.Scope Global => GameEventBus.Global;

        /// <summary>
        /// 현재 활성 씬의 이벤트 버스 스코프입니다.
        /// </summary>
        public static GameEventBus.Scope Scene => GameEventBus.Scene;

        /// <summary>
        /// 이벤트 핸들러를 구독합니다.
        /// </summary>
        /// <typeparam name="TEvent">이벤트 타입입니다.</typeparam>
        /// <param name="handler">호출할 핸들러입니다.</param>
        public static void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : GameEventContext
        {
            GameEventBus.Subscribe(handler);
        }

        /// <summary>
        /// 이벤트 핸들러 구독을 해제합니다.
        /// </summary>
        /// <typeparam name="TEvent">이벤트 타입입니다.</typeparam>
        /// <param name="handler">해제할 핸들러입니다.</param>
        public static void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : GameEventContext
        {
            GameEventBus.Unsubscribe(handler);
        }

        /// <summary>
        /// 이벤트를 발행합니다.
        /// </summary>
        /// <typeparam name="TEvent">이벤트 타입입니다.</typeparam>
        /// <param name="context">발행할 이벤트 컨텍스트입니다.</param>
        public static void Publish<TEvent>(TEvent context) where TEvent : GameEventContext
        {
            GameEventBus.Publish(context);
        }
    }
}
