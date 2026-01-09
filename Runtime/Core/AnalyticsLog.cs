using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace ZGS.Analytics
{
    /// <summary>
    /// 条件日志工具 - 仅在编辑器中输出
    /// </summary>
    internal static class AnalyticsLog
    {
        [Conditional("UNITY_EDITOR")]
        public static void Log(string message)
        {
            Debug.Log(message);
        }

        [Conditional("UNITY_EDITOR")]
        public static void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }
    }
}
