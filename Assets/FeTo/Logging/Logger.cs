using UnityEngine;

namespace FeTo.Logging
{
    public static class Logger
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Info(string message)
        {
            Debug.Log(message);
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Warn(string message)
        {
            Debug.LogWarning(message);
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Error(string message)
        {
            Debug.LogError(message);
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToInfo(bool shouldLog, string message)
        {
            if (shouldLog) { Info(message); }
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToWarn(bool shouldLog, string message)
        {
            if (shouldLog) { Warn(message); }
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToError(bool shouldLog, string message)
        {
            if (shouldLog) { Error(message); }
        }
    }
}
