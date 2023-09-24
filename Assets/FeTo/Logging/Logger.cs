using UnityEngine;

namespace FeTo.Logging
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/Logging#feto-logger")]
    public static class Logger
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Info(string message, Object context = null)
        {
            Debug.Log(message, context);
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Warn(string message, Object context = null)
        {
            Debug.LogWarning(message, context);
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void Error(string message, Object context = null)
        {
            Debug.LogError(message, context);
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToInfo(bool shouldLog, string message, Object context = null)
        {
            if (shouldLog) { Info(message, context); }
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToWarn(bool shouldLog, string message, Object context = null)
        {
            if (shouldLog) { Warn(message, context); }
        }

        [System.Diagnostics.Conditional("FETO_LOGS")]
        internal static void FeToError(bool shouldLog, string message, Object context = null)
        {
            if (shouldLog) { Error(message, context); }
        }
    }
}
