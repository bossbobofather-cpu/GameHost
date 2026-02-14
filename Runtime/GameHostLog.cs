using System;
using System.Diagnostics;

namespace Noname.GameHost
{
    /// <summary>
    /// GameHost 공용 로그 출력 진입점입니다.
    /// </summary>
    public static class GameHostLog
    {
        /// <summary>
        /// 정보 로그 출력 델리게이트입니다.
        /// </summary>
        public static Action<string> Info = message => Debug.WriteLine(message);

        /// <summary>
        /// 경고 로그 출력 델리게이트입니다.
        /// </summary>
        public static Action<string> Warning = message => Debug.WriteLine(message);

        /// <summary>
        /// 오류 로그 출력 델리게이트입니다.
        /// </summary>
        public static Action<string> Error = message => Debug.WriteLine(message);

        /// <summary>
        /// 정보 로그를 출력합니다.
        /// </summary>
        /// <param name="message">로그 메시지입니다.</param>
        public static void LogInfo(string message) => Info?.Invoke(message);

        /// <summary>
        /// 경고 로그를 출력합니다.
        /// </summary>
        /// <param name="message">로그 메시지입니다.</param>
        public static void LogWarning(string message) => Warning?.Invoke(message);

        /// <summary>
        /// 오류 로그를 출력합니다.
        /// </summary>
        /// <param name="message">로그 메시지입니다.</param>
        public static void LogError(string message) => Error?.Invoke(message);
    }
}
